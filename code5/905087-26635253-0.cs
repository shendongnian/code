    public static PingReply Send(IPAddress srcAddress, IPAddress destAddress, int timeout = 5000, byte[] buffer = null, PingOptions po = null)
    {
        if (destAddress == null || destAddress.AddressFamily != AddressFamily.InterNetwork || destAddress.Equals(IPAddress.Any))
            throw new ArgumentException();
     
        //Defining pinvoke args
        var source = srcAddress == null ? 0 : BitConverter.ToUInt32(srcAddress.GetAddressBytes(), 0);
        var destination = BitConverter.ToUInt32(destAddress.GetAddressBytes(), 0);
        var sendbuffer = buffer ?? new byte[] {};
        var options = new Interop.Option
        {
            Ttl = (po == null ? (byte) 255 : (byte) po.Ttl),
            Flags = (po == null ? (byte) 0 : po.DontFragment ? (byte) 0x02 : (byte) 0) //0x02
        };
        var fullReplyBufferSize = Interop.ReplyMarshalLength + sendbuffer.Length; //Size of Reply struct and the transmitted buffer length.
     
        var allocSpace = Marshal.AllocHGlobal(fullReplyBufferSize); // unmanaged allocation of reply size. TODO Maybe should be allocated on stack
        try
        {
            DateTime start = DateTime.Now;
            var nativeCode = Interop.IcmpSendEcho2Ex(
                Interop.IcmpHandle, //_In_      HANDLE IcmpHandle,
                default(IntPtr), //_In_opt_  HANDLE Event,
                default(IntPtr), //_In_opt_  PIO_APC_ROUTINE ApcRoutine,
                default(IntPtr), //_In_opt_  PVOID ApcContext
                source, //_In_      IPAddr SourceAddress,
                destination, //_In_      IPAddr DestinationAddress,
                sendbuffer, //_In_      LPVOID RequestData,
                (short) sendbuffer.Length, //_In_      WORD RequestSize,
                ref options, //_In_opt_  PIP_OPTION_INFORMATION RequestOptions,
                allocSpace, //_Out_     LPVOID ReplyBuffer,
                fullReplyBufferSize, //_In_      DWORD ReplySize,
                timeout //_In_      DWORD Timeout
                );
            TimeSpan duration = DateTime.Now - start;
            var reply = (Interop.Reply) Marshal.PtrToStructure(allocSpace, typeof (Interop.Reply)); // Parse the beginning of reply memory to reply struct
            byte[] replyBuffer = null;
            if (sendbuffer.Length != 0)
            {
                replyBuffer = new byte[sendbuffer.Length];
                Marshal.Copy(allocSpace + Interop.ReplyMarshalLength, replyBuffer, 0, sendbuffer.Length); //copy the rest of the reply memory to managed byte[]
            }
     
            if (nativeCode == 0) //Means that native method is faulted.
                return new PingReply(nativeCode, reply.Status, new IPAddress(reply.Address), duration);
            else
                return new PingReply(nativeCode, reply.Status, new IPAddress(reply.Address), reply.RoundTripTime, replyBuffer);
        }
        finally
        {
            Marshal.FreeHGlobal(allocSpace); //free allocated space
        }
    }
     
    /// <summary>Interoperability Helper
    ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/bb309069(v=vs.85).aspx" />
    /// </summary>
    private static class Interop
    {
        private static IntPtr? icmpHandle;
        private static int? _replyStructLength;
     
        /// <summary>Returns the application legal icmp handle. Should be close by IcmpCloseHandle
        ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa366045(v=vs.85).aspx" />
        /// </summary>
        public static IntPtr IcmpHandle
        {
            get
            {
                if (icmpHandle == null)
                {
                    icmpHandle = IcmpCreateFile();
                    //TODO Close Icmp Handle appropiate
                }
     
                return icmpHandle.GetValueOrDefault();
            }
        }
        /// <summary>Returns the the marshaled size of the reply struct.</summary>
        public static int ReplyMarshalLength
        {
            get
            {
                if (_replyStructLength == null)
                {
                    _replyStructLength = Marshal.SizeOf(typeof (Reply));
                }
                return _replyStructLength.GetValueOrDefault();
            }
        }
     
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern IntPtr IcmpCreateFile();
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        private static extern bool IcmpCloseHandle(IntPtr handle);
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint IcmpSendEcho2Ex(IntPtr icmpHandle, IntPtr Event, IntPtr apcroutine, IntPtr apccontext, UInt32 sourceAddress, UInt32 destinationAddress, byte[] requestData, short requestSize, ref Option requestOptions, IntPtr replyBuffer, int replySize, int timeout);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Option
        {
            public byte Ttl;
            public readonly byte Tos;
            public byte Flags;
            public readonly byte OptionsSize;
            public readonly IntPtr OptionsData;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Reply
        {
            public readonly UInt32 Address;
            public readonly int Status;
            public readonly int RoundTripTime;
            public readonly short DataSize;
            public readonly short Reserved;
            public readonly IntPtr DataPtr;
            public readonly Option Options;
        }
    }
    [Serializable]
    public class PingReply
    {
        private readonly byte[] _buffer = null;
        private readonly IPAddress _ipAddress = null;
        private readonly uint _nativeCode = 0;
        private readonly TimeSpan _roundTripTime = TimeSpan.Zero;
        private readonly IPStatus _status = IPStatus.Unknown;
        private Win32Exception _exception;
     
        internal PingReply(uint nativeCode, int replystatus, IPAddress ipAddress, TimeSpan duration)
        {
            _nativeCode = nativeCode;
            _ipAddress = ipAddress;
            if (Enum.IsDefined(typeof (IPStatus), replystatus))
                _status = (IPStatus) replystatus;
        }
        internal PingReply(uint nativeCode, int replystatus, IPAddress ipAddress, int roundTripTime, byte[] buffer)
        {
            _nativeCode = nativeCode;
            _ipAddress = ipAddress;
            _roundTripTime = TimeSpan.FromMilliseconds(roundTripTime);
            _buffer = buffer;
            if (Enum.IsDefined(typeof (IPStatus), replystatus))
                _status = (IPStatus) replystatus;
        }
     
        /// <summary>Native result from <code>IcmpSendEcho2Ex</code>.</summary>
        public uint NativeCode
        {
            get { return _nativeCode; }
        }
        public IPStatus Status
        {
            get { return _status; }
        }
        /// <summary>The source address of the reply.</summary>
        public IPAddress IpAddress
        {
            get { return _ipAddress; }
        }
        public byte[] Buffer
        {
            get { return _buffer; }
        }
        public TimeSpan RoundTripTime
        {
            get { return _roundTripTime; }
        }
        /// <summary>Resolves the <code>Win32Exception</code> from native code</summary>
        public Win32Exception Exception
        {
            get
            {
                if (Status != IPStatus.Success)
                    return _exception ?? (_exception = new Win32Exception((int) NativeCode, Status.ToString()));
                else
                    return null;
            }
        }
     
        public override string ToString()
        {
            if (Status == IPStatus.Success)
                return Status + " from " + IpAddress + " in " + RoundTripTime + " ms with " + Buffer.Length + " bytes";
            else if (Status != IPStatus.Unknown)
                return Status + " from " + IpAddress;
            else
                return Exception.Message + " from " + IpAddress;
        }
    }

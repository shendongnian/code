    public class VaList : IDisposable
    {
        protected readonly List<GCHandle> handles = new List<GCHandle>();
        public VaList(bool unicode, params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }
            // The first handle is for the bytes array
            handles.Add(default(GCHandle));
            int total = 0;
            var bytes = new PrimitiveToBytes[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                int size = Convert(unicode, args[i], ref bytes[i]);
                bytes[i].Size = size;
                total += size;
            }
            // Instead of a byte[] we use a IntPtr[], so copying elements
            // inside is faster (perhaps :-) )
            var buffer = new IntPtr[total / IntPtr.Size];
            handles[0] = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            for (int i = 0, j = 0; i < args.Length; i++)
            {
                buffer[j++] = bytes[i].IntPtr;
                // long or double with IntPtr == 4
                if (bytes[i].Size > IntPtr.Size)
                {
                    buffer[j++] = (IntPtr)bytes[i].Int32High;
                }
            }
        }
        // Overload this to handle other types
        protected virtual int Convert(bool unicode, object arg, ref PrimitiveToBytes primitiveToBytes)
        {
            int size;
            if (arg == null)
            {
                primitiveToBytes.IntPtr = IntPtr.Zero;
                size = IntPtr.Size;
            }
            else
            {
                Type type = arg.GetType();
                TypeCode typeHandle = Type.GetTypeCode(type);
                switch (typeHandle)
                {
                    case TypeCode.Boolean:
                        // Boolean converted to Int32
                        primitiveToBytes.Int32 = (bool)arg ? 1 : 0;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.SByte:
                        primitiveToBytes.SByte = (sbyte)arg;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.Byte:
                        primitiveToBytes.Byte = (byte)arg;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.Int16:
                        primitiveToBytes.Int16 = (short)arg;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.UInt16:
                        primitiveToBytes.UInt16 = (ushort)arg;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.Int32:
                        primitiveToBytes.Int32 = (int)arg;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.UInt32:
                        primitiveToBytes.UInt32 = (uint)arg;
                        size = IntPtr.Size;
                        break;
                    case TypeCode.Int64:
                        primitiveToBytes.Int64 = (long)arg;
                        size = sizeof(long);
                        break;
                    case TypeCode.UInt64:
                        primitiveToBytes.UInt64 = (ulong)arg;
                        size = sizeof(ulong);
                        break;
                    case TypeCode.Single:
                        // Single converted to Double
                        primitiveToBytes.Double = (double)(float)arg;
                        size = sizeof(double);
                        break;
                    case TypeCode.Double:
                        primitiveToBytes.Double = (double)arg;
                        size = sizeof(double);
                        break;
                    case TypeCode.Char:
                        if (unicode)
                        {
                            primitiveToBytes.UInt16 = (char)arg;
                        }
                        else
                        {
                            byte[] bytes = Encoding.Default.GetBytes(new[] { (char)arg });
                            if (bytes.Length > 0)
                            {
                                primitiveToBytes.B0 = bytes[0];
                                if (bytes.Length > 1)
                                {
                                    primitiveToBytes.B1 = bytes[1];
                                    if (bytes.Length > 2)
                                    {
                                        primitiveToBytes.B2 = bytes[2];
                                        if (bytes.Length > 3)
                                        {
                                            primitiveToBytes.B3 = bytes[3];
                                        }
                                    }
                                }
                            }
                        }
                        size = IntPtr.Size;
                        break;
                    case TypeCode.String:
                        {
                            string str = (string)arg;
                            GCHandle handle;
                            if (unicode)
                            {
                                handle = GCHandle.Alloc(str, GCHandleType.Pinned);
                            }
                            else
                            {
                                byte[] bytes = new byte[Encoding.Default.GetByteCount(str) + 1];
                                Encoding.Default.GetBytes(str, 0, str.Length, bytes, 0);
                                handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                            }
                            handles.Add(handle);
                            primitiveToBytes.IntPtr = handle.AddrOfPinnedObject();
                            size = IntPtr.Size;
                        }
                        break;
                    case TypeCode.Object:
                        if (type == typeof(IntPtr))
                        {
                            primitiveToBytes.IntPtr = (IntPtr)arg;
                            size = IntPtr.Size;
                        }
                        else if (type == typeof(UIntPtr))
                        {
                            primitiveToBytes.UIntPtr = (UIntPtr)arg;
                            size = UIntPtr.Size;
                        }
                        else if (!type.IsValueType)
                        {
                            GCHandle handle = GCHandle.Alloc(arg, GCHandleType.Pinned);
                            primitiveToBytes.IntPtr = handle.AddrOfPinnedObject();
                            size = IntPtr.Size;
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return size;
        }
        ~VaList()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            for (int i = 0; i < handles.Count; i++)
            {
                if (handles[i].IsAllocated)
                {
                    handles[i].Free();
                }
            }
            handles.Clear();
        }
        public IntPtr AddrOfPinnedObject()
        {
            if (handles.Count == 0)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
            return handles[0].AddrOfPinnedObject();
        }
        [StructLayout(LayoutKind.Explicit)]
        protected struct PrimitiveToBytes
        {
            [FieldOffset(0)]
            public byte B0;
            [FieldOffset(1)]
            public byte B1;
            [FieldOffset(2)]
            public byte B2;
            [FieldOffset(3)]
            public byte B3;
            [FieldOffset(4)]
            public byte B4;
            [FieldOffset(5)]
            public byte B5;
            [FieldOffset(6)]
            public byte B6;
            [FieldOffset(7)]
            public byte B7;
            [FieldOffset(4)]
            public int Int32High;
            [FieldOffset(0)]
            public byte Byte;
            [FieldOffset(0)]
            public sbyte SByte;
            [FieldOffset(0)]
            public short Int16;
            [FieldOffset(0)]
            public ushort UInt16;
            [FieldOffset(0)]
            public int Int32;
            [FieldOffset(0)]
            public uint UInt32;
            [FieldOffset(0)]
            public long Int64;
            [FieldOffset(0)]
            public ulong UInt64;
            [FieldOffset(0)]
            public float Single;
            [FieldOffset(0)]
            public double Double;
            [FieldOffset(0)]
            public IntPtr IntPtr;
            [FieldOffset(0)]
            public UIntPtr UIntPtr;
            [FieldOffset(8)]
            public int Size;
        }
    }

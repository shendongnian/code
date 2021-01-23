    public static class MidiTest { // version 3 - x68/x64 32/64-bit compatible
    
      public static void Test () {
        int moID = 0; // midi out device/port ID
        IntPtr moHdl = IntPtr.Zero;
    
    #if !true
        // SysEx via midiOutLongMsg works
        Chk (WinMM.midiOutOpen (out moHdl, moID, null, 0, 0)); // open midi out in non-stream mode
    #else
        // SysEx via midiOutLongMsg fails
        IntPtr instance = IntPtr.Zero;
        Chk (WinMM.midiStreamOpen (out moHdl, ref moID, 1, null, instance, 0)); // open midi out in stream mode
    #endif
        byte[] sx = { 0xF0, 0x7E, 0x7F, 0x09, 0x01, 0xF7 }; // GM On sysex
    
        int shdr = Marshal.SizeOf(typeof(MidiHdr)); // hdr size
        IntPtr x = Marshal.OffsetOf (typeof (MidiHdr), "data");   // ptr; size: 4/8, offset: 0
        x = Marshal.OffsetOf (typeof (MidiHdr), "bufferLength");  // int; size: 4  , offset: 4/8
        x = Marshal.OffsetOf (typeof (MidiHdr), "bytesRecorded"); // int; size: 4  , offset: 8/12
        x = Marshal.OffsetOf (typeof (MidiHdr), "user");          // ptr; size: 4/8, offset: 12/16
        x = Marshal.OffsetOf (typeof (MidiHdr), "flags");         // int; size: 4  , offset: 16/24; followed by 4 byte padding
        x = Marshal.OffsetOf (typeof (MidiHdr), "next");          // ptr; size: 4/8, offset: 20/32
        x = Marshal.OffsetOf (typeof (MidiHdr), "reserved");      // ptr; size: 4/8, offset: 24/40
        x = Marshal.OffsetOf (typeof (MidiHdr), "offset");        // int; size: 4  , offset: 28/48; followed by 4 byte padding
        x = Marshal.OffsetOf (typeof (MidiHdr), "reservedArray"); // ptr; size: 4/8 x 8 = 32/64, offset: 32/56
        // total size: 64/120
        var mhdr = new MidiHdr (); // allocate managed hdr
        mhdr.bufferLength = mhdr.bytesRecorded = sx.Length; // length of message bytes
        mhdr.data = Marshal.AllocHGlobal (mhdr.bufferLength); // allocate native message bytes
        Marshal.Copy (sx, 0, mhdr.data, mhdr.bufferLength); // copy message bytes from managed to native memory
        IntPtr nhdr = Marshal.AllocHGlobal (shdr); // allocate native hdr
        Marshal.StructureToPtr (mhdr, nhdr, false); // copy managed hdr to native hdr
        Chk (WinMM.midiOutPrepareHeader (moHdl, nhdr, shdr)); // prepare native hdr
        int r = WinMM.midiOutLongMsg (moHdl, nhdr, shdr); // send native message bytes
        Chk (r); // send native message bytes
      } // Test
    
      static void Chk (int f) {
        if (0 == f) return;
        var sb = new StringBuilder (256); // MAXERRORLENGTH
        var s = 0 == WinMM.midiOutGetErrorText (f, sb, sb.Capacity) ? sb.ToString () : String.Format ("MIDI Error {0}.", f);
        System.Diagnostics.Trace.WriteLine (s);
      }
    
      [StructLayout (LayoutKind.Sequential)]
      internal struct MidiHdr { // sending long MIDI messages requires a header
        public IntPtr data; // native pointer to message bytes, allocated on native heap
        public int bufferLength; // length of buffer 'data'
        public int bytesRecorded; // actual amount of data in buffer 'data'
        public IntPtr user; // custom user data
        public int flags; // information flags about buffer
        public IntPtr next; // reserved
        public IntPtr reserved; // reserved
        public int offset; // buffer offset on callback
        [MarshalAs (UnmanagedType.ByValArray, SizeConst = 8)]
        public IntPtr[] reservedArray; // reserved
      } // struct MidiHdr
    
      internal sealed class WinMM { // native MIDI calls from WinMM.dll
        public delegate void CB (IntPtr hdl, int msg, IntPtr inst, int p1, int p2); // callback
        [DllImport ("winmm.dll")] public static extern int midiStreamOpen (out IntPtr hdl, ref int devID, int reserved, CB proc, IntPtr inst, uint flags);
        [DllImport ("winmm.dll")] public static extern int midiOutOpen (out IntPtr hdl, int devID, CB proc, IntPtr instance, int flags);
        [DllImport ("winmm.dll")] public static extern int midiOutPrepareHeader (IntPtr hdl, IntPtr pHdr, int sHdr);
        [DllImport ("winmm.dll")] public static extern int midiOutLongMsg (IntPtr hdl, IntPtr pHdr, int sHdr);
        [DllImport ("winmm.dll")] public static extern int midiOutGetErrorText (int err, StringBuilder msg, int sMsg);
      } // class WinMM
    
    } // class MidiTest

    StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TestData :BaseStructure
    {
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bytes = new byte[]{65,66,67}; 
    }

    [ProgId("ArrayTest.FillAray")]
    [GuidAttribute("51E7819D-3EF3-4498-B5BE-5D6B8EF98176")] // some guid
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class FillArray : FillArrayI
    {
        public byte[] result_array{ set; get; }
        public int fill_result_array()
        {
            result_array = new byte[95];
            for(int i = 0; i < 95; result_array[i] = i+32;
            return 0;
        }
    }

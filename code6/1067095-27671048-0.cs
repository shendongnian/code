    [StructLayout(LayoutKind.Sequential)]
    public class MyStruct
    {
        private byte _test;
        public bool Test {
           get { return _test != 0; }
           set { _test = value ? 1 : 0; }
        }
    }

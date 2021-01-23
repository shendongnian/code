    [ComVisible(true)]
    [Guid("9F2B6958-742F-4E5D-A5F3-D6BDC6C841DB")]
    [ProgId("COMTests.Class1")]
    public class Class1
    {
        public void M(dynamic foo)
        {
            Console.WriteLine("foo:" + foo.i);
        }
    }

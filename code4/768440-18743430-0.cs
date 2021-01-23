    [Guid(123565C4-C5FA-4512-A560-1D47F9FDFA20")]
    public interface ISomeInteface
    {
        [DispId(1)]
        string FirstFunction{ get; }
        [DispId(2)]
        void SecondFunction();
    }
    [ComVisible(true)]
    [Guid(123565C4-C5FA-4512-A560-1D47F9FDFA20")]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class SomeInteface: ISomeInteface
    {
        public SomeInteface()
        {
        }
       public string FirstFunction
       {
       	get { return "Work here"; }
       }
        public void SecondFunction()
       {
       }
    }

    [Guid("B1E17DF6-9578-4D24-B578-9C70979E2F05")]
    public interface _Class1
    {
        [DispId(2)]
        string Message { get; }
        [DispId(1)]
        string TestingAMethod();
    }
    [Guid("197A7A57-E59F-41C9-82C8-A2F051ABA53C")]
    [ProgId("Project.Class1")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Class1 : _Class1
    {
        public string Message { get; private set; }
        public Class1(string message)
        {
            this.Message = message;
        }
        public string TestingAMethod()
        {
            return "Hello World";
        }
    }

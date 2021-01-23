    [Guid("197A7A57-E59F-41C9-82C8-A2F051ABA53C")]
    [ProgId("Project.Class1")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Class1 : _Class1
    {
        private bool _isMessageSet = false;
        private string _message;
        public string Message 
        { 
            get { return _message; }
            set
            {
                if (!_isMessageSet)
                {
                    _message = value;
                    _isMessageSet = true;
                }
            }
        }
        public Class1() { } //default constructor for COM
        public Class1(string message)
        {
            this.Message = message;
        }
    }

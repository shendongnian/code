    public class Foo
    {
        public Foo(string message)
        {
            Message = message;
            _timeStamp = DateTime.Now;
        }
    
        private Foo(string message, DateTime timeStamp)
        {
            Message = message;
            _timeStamp = timeStamp;
        }
    
        public string Message { get; private set; }
        //Because this field is marked readonly it must be set inside a constructor.
        private readonly DateTime _timeStamp;
        public DateTime TimeStamp {get { return _timeStamp; } }
    
        public static Foo GetFooFromFile(string path)
        {
            var fileText = File.ReadAllText(path);
            var fileTimeStamp = File.GetCreationTime(path);
            //this constructor can only be used inside this function because it is marked private.
            return new Foo(fileText, fileTimeStamp);
        }
    }

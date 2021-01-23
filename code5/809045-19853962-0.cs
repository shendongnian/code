    public class Foo
    {
        public Foo(string message)
        {
            Message = message;
            TimeStamp = DateTime.Now;
        }
    
        private Foo(string message, DateTime timeStamp)
        {
            Message = message;
            TimeStamp = timeStamp;
        }
    
        public string Message { get; private set; }
        public DateTime TimeStamp {get; private set; }
    
        public static Foo GetFooFromFile(string path)
        {
            var fileText = File.ReadAllText(path);
            var fileTimeStamp = File.GetCreationTime(path);
            //this constructor can only be used inside this function because it is marked private.
            return new Foo(fileText, fileTimeStamp);
        }
    }

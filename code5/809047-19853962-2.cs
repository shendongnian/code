    public class TimeStampedMessage
    {
        public TimeStampedMessage(string message)
        {
            Message = message;
            _timeStamp = DateTime.Now;
        }
    
        private TimeStampedMessage(string message, DateTime timeStamp)
        {
            Message = message;
            _timeStamp = timeStamp;
        }
    
        public string TimeStampedMessage { get; private set; }
        //Because this field is marked readonly it must be set inside a constructor.
        private readonly DateTime _timeStamp;
        public DateTime TimeStamp {get { return _timeStamp; } }
    
        public static TimeStampedMessage GetMessageFromFile(string path)
        {
            var fileText = File.ReadAllText(path);
            var fileTimeStamp = File.GetCreationTime(path);
            //this constructor can not be used by a end user because it is marked private, but it can be used here inside the function.
            return new Foo(fileText, fileTimeStamp);
        }
    }

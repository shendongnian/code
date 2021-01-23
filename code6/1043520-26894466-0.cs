       public class OriginalClass
    {
        IPersistence _persistence;
        public OriginalClass(IPersistence persistence)
        {
            this._persistence = persistence;
        }
        public void DoSomething()
        {
            // I have all the information needed to send an email / save to disk. But how do I supply it?
            this._persistence.Put("Message to save");
        }
    }
    public interface IPersistence
    {
        bool Put<T>(T data);
    }
    public class EmailPersistence : IPersistence
    {
        private readonly IEmailManager _manager;
        public EmailPersistence(IEmailManager manager)
        {
            _manager = manager;
        }
        public bool Put<T>(T data)
        {
            // How am I going to get the FROM and TO details?
            return _manager.Send();
        }
    }
    public class EmailManager : IEmailManager
    {
        public string From { get; set; }
        public string To { get; set; }
        
        public bool Send()
        {
            throw new NotImplementedException();
        }
        public dynamic Data { get; set; }
    }
    public interface IEmailManager
    {
        string From { get; set; }
        string To { get; set; }
        dynamic Data { get; set; }
        bool Send();
    }
    public class DiskPersistence : IPersistence
    {
        public string Path { get; set; }
        public DiskPersistence(string path)
        {
            Path = path;
        }
        public bool Put<T>(T data)
        {
            // How am I going to get the SAVE PATH details?
            // I just used a new initialization. So I'm probably doing this wrong as well...
            new System.IO.StreamWriter(Path).Write(data.ToString());
            return true;
        }
    }

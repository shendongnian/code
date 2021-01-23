    public class SmsHandler : IRequestHandler<EventArgs>
    {
        private IDataRepository dataRepository;
        public SmsHandler(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        public event EventHandler<EventArgs> EventHandler;
        public void Start()
        {
            // save your data or something.. 
            dataRepository.Save(new object());
            // do start
        }
        public void Stop()
        {
            // do end
        }
    }
    public class EmailHandler : IRequestHandler<EventArgs>
    {
        private IDataRepository dataRepository;
        public EmailHandler(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        public event EventHandler<EventArgs> EventHandler;
        public void Start()
        {
            // do start
        }
        public void Stop()
        {
            // do end
        }
    }
    public interface IDataRepository
    {
        // or whatever you need here
        void Save(object data);
    }
    public class FlatFileDataRepositories : IDataRepository
    {
        public void Save(object data)
        {
            // save in file
        }
    }
    public class DatabaseRepository : IDataRepository
    {
        public void Save(object data)
        {
            // save in the database
        }
    }

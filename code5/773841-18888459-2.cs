        public interface ISampleClientContract
        {
            [OperationContract(IsOneWay = true)]
            void AnnounceSomeStuff();
        }
    
        public class Subscriber
        {
        	public ISampleClientContract Callback { get; set; }
        	public Guid ID { get; set; }
        }
        
        private List<Subscriber> MyClients = new List<Subscriber>();
        
        public void Subscribe(Guid id)
        {
        	MyClients.Add(new Subscriber
        		{ 
        			Callback = OperationContext.Current.GetCallbackChannel<ISampleClientContract>()
        			ID = id
        		});
        }
        
        public void Unsubscribe(Guid ID)
        {
        	MyClients.Remove(o => o.ID == id).First());
        }
        
        public void NotifyClient(Guid id)
        {
        	try
        	{
        		MyClients.Where( o => o.ID == id).First().Callback.AnnounceSomeStuff();
        	}
        	catch
        	{
        		MyClients.Remove(MyClients.Where(o => o.ID == id).first()); //instance dead?
        	}
        }
        
        public void AnnounceToAll()
        {
        	MyClients.ForEach(o => o.Callback.AnnounceSomeStuff());
        }

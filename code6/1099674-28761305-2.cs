    public class XmlSerialization : INotifier
    {
        private readonly IRepository[] repositories; 
        public XmlSerialization(params IRepository[] repositories)
        {
          this.repositories= repositories;
        }
        public void Notify()
        {
           foreach (var repo in repositories)
           {        
              repo.Save();
           }       
        }      
    }

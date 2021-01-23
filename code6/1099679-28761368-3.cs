    public class XmlSerialization : INotifier
    {
        private readonly IRepository[] _repositories;
        public XmlSerialization(params IRepository[] repositories)
        {
            this._repositories = repositories;
        }
        public void Notify()
        {
            foreach (IRepository repository in this._repositories)
            {
                repository.Save();
            }
        }
    }

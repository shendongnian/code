    public class DataObject
    {
        public void DataObject()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id{ get; private set; }
    }

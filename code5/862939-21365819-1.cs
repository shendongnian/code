    public abstract class AbstractDomainObject
    {
        private int _id = -1;
        public int ID
        {
            get
            {
                if (_id == -1)
                {
                    throw new InvalidOperationException("domain object not yet persisted");
                }
                return _id;
            }
            set
            {
                if (_id != -1)
                {
                    throw new InvalidOperationException("domain object already persisted");
                }
                _id = value;
            }
        public bool IsPersisted
        {
            get
            {
                return _id != -1;
            }
        }
    }

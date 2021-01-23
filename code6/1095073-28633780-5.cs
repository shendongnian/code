    public class SomeClass
    {
        private readonly DateTime validFrom;
        private readonly DateTime expirationDate;
        public SomeClass(DateTime x, DateTime y)
        {
            if (x < y)
            {
                this.validFrom = x;
                this.expirationDate = y;
            }
            else
            {
                this.validFrom = y;
                this.expirationDate = x;
            }
        }
        public DateTime ValidFrom
        {
            get { return this.validFrom; }
        }
        public DateTime ExpirationDate
        {
            get { return this.expirationDate; }
        }
    }

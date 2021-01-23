    public class TelephoneNumber
    {
        private TelephoneNumber()
        {
        }
        public TelephoneNumber(string areaCode, string subscriberNumber)
        {
            this.AreaCode = areaCode;
            this.SubscriberNumber = subscriberNumber;
        }
        public string AreaCode
        {
            get
            {
                return this.areaCode;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("AreaCode");
                }
                if ((value.Length <= 0) || (value.Length > 5))
                {
                    throw new ArgumentOutOfRangeException("AreaCode");
                }
                this.areaCode = value;
            }
        }
        // Etc.
    }

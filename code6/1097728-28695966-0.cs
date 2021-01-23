    public class ParentClass
    {
        private string userName;
        public virtual string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        private string accountNumber; // don't see a reason why it should be a property rather than a field...
        private int userAge;
        internal int UserAge
        {
            get
            {
                return userAge;
            }
            set
            {
                userAge = value;
            }
        }
        protected string phoneNumber;
        public virtual string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        public ParentClass()
        {
            // potentially do something intresting
        }
    }

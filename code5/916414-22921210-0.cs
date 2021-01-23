    public partial Entity
    {
        public DateTime UseThisDate
        {
            get { return ToUserLocalTime(BackendDate); }
            set { BackendDate = ToUTC(value); }
        }
    }

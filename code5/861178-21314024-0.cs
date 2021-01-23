    public partial class Customer
    {
        public Customer()
        {
            this.Blocked = false;
            this.Code = "#00000";
            this.RuleId = 1;
            this.LocationId = 1;
            this.Contacts = new ObservableListSource<Contact>();
            AdditionnalInitialisation();
        }
        private partial void AdditionnalInitialisation();

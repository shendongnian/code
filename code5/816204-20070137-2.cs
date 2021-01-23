    public class EmployeeType : Enumeration
    {
        public static Func<IBonusService> BonusService { private get; set; }
        private static EmployeeType _manager = null;
        public static EmployeeType Manager { 
            get 
            {
                if (_manager == null) _manager = new ManagerType(BonusService());
                return _manager;
            } }
        public static readonly EmployeeType Servant
            = new EmployeeType(1, "Servant");
        public static readonly EmployeeType AssistantToTheRegionalManager
            = new EmployeeType(2, "Assistant to the Regional Manager");
        private EmployeeType(int value, string displayName) :
           base(value, displayName) { }
        public virtual decimal BonusSize { get { return 0; } }
        private class ManagerType : EmployeeType
        {
            private readonly IBonusService service;
            public ManagerType(IBonusService service) : base(0, "Manager")
            {
                this.service = service;
            }
            public override decimal BonusSize {
                get { return this.service.currentManagerBonus; } }
        }
    }

    class Role
    {
        public virtual string Destination { get { return "Home"; } }
    }
    class Manager : Role
    {
        public override string Destination { get { return "ManagerHome;"; } }
    }
    class Accountant : Role
    {
        public override string Destination { get { return "AccountantHome;"; } }
    }
    class Attender : Role
    {
        public override string Destination { get { return "AttenderHome;"; } }
    }
    class Cleaner : Role
    {
        public override string Destination { get { return "CleanerHome;"; } }
    }
    class Security : Role { }

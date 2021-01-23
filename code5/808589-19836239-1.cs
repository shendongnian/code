    // same namespace as the auto-generated class
    public partial class Client
    {
        public string MyName
        {
            get { return Name ?? ""; }
            set { Name = (value == "" ? null : value); }
        }
    }

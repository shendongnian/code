    public class MyTable
    {
        private string Active { get; set; }
        public bool IsActive 
        {
            get { return Active == "T"; }
            set { Active = value ? "T" : "F"; }
        }
    }

        public partial class SiteMaster : MasterPage
        {
            public string PropertyInMaster { get; set; }
    
            protected void Page_Init(object sender, EventArgs e)
            {
                PropertyInMaster = "test";
    ...

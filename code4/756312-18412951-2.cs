    class ListingItem
    {
        //private string title;
        //private string user;
        //private string category;
    
        public string Title { get; set; }
        public string User { get; set; }
        public string Category { get; set; }
    
        //Dummy constructor for test purposes
        public ListingItem()
        {
            Title = "TestTitle";
            User = "TestUser";
            Category = "TestCatagory";
        }
    }

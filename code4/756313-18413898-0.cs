class ListingItem
    {
        public  string title { get; set; }
        public string user { get; set; }
        public string category { get; set; }
    
        //Dummy constructor for test purposes
        public ListingItem()
        {
            title = "TestTitle";
            user = "TestUser";
            category = "TestCatagory";
        }
    }

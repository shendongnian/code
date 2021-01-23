        public MyCollection<string> Collection1 { get; set; }
        public MyCollection<string> Collection2 { get; set; } 
        public void Initialise()
        {
            Collection1 = new MyCollection<string> { MyCount = 0 };
            Collection2 = new MyCollection<string> { MyCount = 0 };
            Collection2.CollectionChanged += (s, a) =>
                {
                    // do something here
                };
        }

    public class NameIdClass
    {
        public string Name { get; set; }
        public string ID{ get; set; }
    }
    public class ViewModel
    {
        public List<NameIdClass> Items
        {
            get
            {
                return new List<NameIdClass>
                {
                    new NameIdClass { Name = "Terry", ID = 122 },
                    new NameIdClass { Name = "John", ID = 234 }
                };
            }
        }
    }
    //This can be done in the Loaded event of the page:
    DataContext = new MyViewModel();

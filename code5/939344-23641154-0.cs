    public partial class Page
    {
        public String Name { get; private set; }
        public String Icon { get; private set; }
    
        public Page(String name, String icon)
        {
            Name = name;
            Icon = icon;
        }
    }

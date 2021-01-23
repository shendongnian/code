    public class Animal
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public string Description
        {
            get { return string.Format("{0} {1}, Color, Name); }  // Gray Dog, Purple Unicorn
        }
    }
    Resultlst.DisplayMember = "Description";

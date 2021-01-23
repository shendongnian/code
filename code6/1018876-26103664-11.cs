    public class ComboboxItem
    {
        public string Name { get; set; }
        public object URL { get; set; }
        public ColorContainer CContainer { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

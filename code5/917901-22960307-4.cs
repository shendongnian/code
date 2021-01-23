    public class ComboBoxItem
    {
        public string Title { get; set; }
        public Func<IMyInterface> creator { get; set; }        
        public override string ToString()
        {
            return Title;
        }
    }

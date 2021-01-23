    public class Height
    {
        public Height() 
        {
            this.GridHeight = new GridLength(200);
        }
        // Needs to be a property for data binding
        public GridLength GridHeight { get; set; }
    }

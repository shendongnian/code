    public sealed class MyCustomControl : UserControl
    {
        // Adding some Controls for testing
        public Label MyLabel1 { get; set; }
        public Label MyLabel2 { get; set; }
        
        // Adding a Component (not a Control) for testing
        public System.Windows.Forms.Timer MyTimer1 { get; set; }
    
        public IEnumerable<Component> EnumerateComponents()
        {
            return this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => typeof(Component).IsAssignableFrom(x.PropertyType))
                .Select(x => x.GetValue(this)).Cast<Component>();
        }
        public IEnumerable<PropertyInfo> EnumerateProperties()
        {
        
            return this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => typeof(Component).IsAssignableFrom(x.PropertyType));
        }
    }

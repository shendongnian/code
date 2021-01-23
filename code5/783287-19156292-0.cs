    using AvalonDock; // or whatever the dll is called
    public class ExtendedClass : OriginalClassToExtend
    {
        private string subTitle = string.Empty;
        public ExtendedClass() : base()
        {
            // Add new functionality to constructor
        }
        public string SubTitle { get; set; }
    }

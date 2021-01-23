    public class CustomPanel : Panel
    {
        public string Description { get; set; }
        protected override Size MeasureOverride(Size availableSize)
        {
            System.Diagnostics.Debug.WriteLine("Size available for '" + Description + "': " + availableSize.Height);
            return base.MeasureOverride(availableSize);
        }
    }

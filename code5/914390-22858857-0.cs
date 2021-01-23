     public class LongListSelectorExtension : LongListSelector
    {
        protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
        {
            try { return base.MeasureOverride(availableSize); }
            catch (ArgumentException) { return this.DesiredSize; }
        }
    }

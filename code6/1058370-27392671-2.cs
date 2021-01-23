    public class PanoramaFullScreen : Panorama
    {
        protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
        {
            int _extraMargin = -150;                         // calculate how much you need
            availableSize.Width += _extraMargin;
            return base.MeasureOverride(availableSize);
        }
    }

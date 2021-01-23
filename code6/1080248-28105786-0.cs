    public class SolidColorBrushComparer : IEqualityComparer<SolidColorBrush>
    {
        public bool Equals(SolidColorBrush x, SolidColorBrush y)
        {
            return x.Color == y.Color && 
                x.Opacity == y.Opacity;
        }
        public int GetHashCode(SolidColorBrush obj)
        {
            return obj.GetHashCode();
        }
    }

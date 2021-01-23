    namespace Xceed.Wpf.Toolkit.PropertyGrid.Implementation.Attributes
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class RangeAttribute : Attribute
        {
            public RangeAttribute(int min, int max)
            {
                Min = min;
                Max = max;
            }
    
            public int Min { get; private set; }
            public int Max { get; private set; }
        }
    }

    public class MyComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            var type = x.GetType();
            var type2 = y.GetType();
            if (type == typeof(string) && type2 == typeof(string))
            {
                return String.Compare((string)x, (string)y);
            }
            else if (type.IsValueType && type2.IsValueType)
            {
                var comp = Comparer<double>.Default;
                return comp.Compare(Convert.ToDouble(x), Convert.ToDouble(y));
            }
            else
            {
                return 0;
            }
        }
    }

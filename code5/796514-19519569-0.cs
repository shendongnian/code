    namespace System
    {
        public static class Extensions
        {
            public static double AsDouble(this TextBox t)
            {
                double val;
                double.TryParse(t.Text, out val);
                return val;
            }
        }
    }

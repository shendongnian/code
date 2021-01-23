    namespace System
    {
        public static class Extensions
        {
            public static TOut Clone<TOut>(this Car input) where TOut : Car
            {
                var o = Activator.CreateInstance(typeof(TOut));
                foreach (var prop in typeof(Car).GetProperties())
                {
                    prop.SetValue(o, prop.GetValue(input));
                }
            }
        }
    }

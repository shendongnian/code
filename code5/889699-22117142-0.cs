    public static class ColorsHelper
        {
            private static readonly Dictionary<string, Color> dict =
                  typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                  .Where(prop => prop.PropertyType == typeof(Color))
                  .ToDictionary(prop => prop.Name, prop => (Color)prop.GetValue(null, null));
    
            public static Color FromName(string name)
            {
                return dict[name];
            }
        }
    textBox1.Background = new SolidColorBrush(ColorsHelper.FromName("Red"));

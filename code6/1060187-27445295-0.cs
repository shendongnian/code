    public class MyBrushLookupConverter : DependencyObject, IValueConverter
    {
       // This is a dependency property - dependency property gumf omitted for brevity
       public Dictionary<string, Brush> BrushDictionary {get; set;}
       // Convert method
       public Convert(object value, ...)
       {
          return BrushDictionary[(string)value];
       }
    }

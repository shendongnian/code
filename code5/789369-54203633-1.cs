    public class VisibilitySetter:IValueConverter 
    {
      public object Convert(object value,Type targetType,object parameter,CultureInfo culture)
      {
        if(parameter.ToString() == "1")  //Parameter is set in the xaml file.
        {
          return SetVisibilityBasedOn(value);
        }
        return null;
      }
      private object SetVisibilityBasedOn(object value)
      {
        if(value is SomeObject obj && obj.value == "SomeValue") //Checks the value of the object
        {        
          return Visibility.Collapsed;  //Hides the row. It Returns visibility based on the value of the row.
        }
        return null;
      }
    }

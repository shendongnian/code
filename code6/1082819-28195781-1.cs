    public class MyTemplateSelector : DataTemplateSelector
    {
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
        var myObj= item as MyObject;
        if (myObj != null) 
        {
          if (myObj.MyType is PostalCode)
          {
             return Application.Resources["TextBoxTemplate"] as DataTemplate;
          }
          if (myObj.MyType  is YesNo)
          {
            return Application.Resources["CheckBoxTemplate"] as DataTemplate;
          }
        }
    
        return null; 
      }
    }

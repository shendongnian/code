    public class MyTemplateSelector : DataTemplateSelector
    {
          public DataTemplate FirstTemplate { get; set; }
          public DataTemplate SecondTemplate { get; set; }
          public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
          {
                   var model = item as ComponentParameter;
 
                   if (model.IsDuplicated)
                        return FirstTemplate;
                  return SecondTemplate;
          }
    }

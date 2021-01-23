    public class MyClass
    {
          public bool MyProperty {get;set;}
          public bool IsExpanded {get;set;}
          public MyClass()
          {
              PropertyChanged += (s,e) =>
              {
                  if (e.PropertyName == "IsExpanded")
                       // change properties
              }
          }
    }
    
    <Expander IsExpanded="{Binding IsExpanded}">

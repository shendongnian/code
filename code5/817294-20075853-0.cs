      Convert()
      {
           return value Is ISomeInterface ? 
                  (((ISomeInterface)value).SomeEnumeration == SomeEnumeration.SomeValue ? 
                  Visibility.Visible :  Visibility.Collapsed) : Visibility.Collapsed;       
      }

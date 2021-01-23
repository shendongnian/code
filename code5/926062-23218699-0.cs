     public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(Choice));
         public string Text
         {
              get { return (string)GetValue(TextProperty); }
              set { SetValue(TextProperty, value); }
         }
     
         public static DependencyProperty Choice4Property = DependencyProperty.Register("Choice4", typeof(Choice), typeof(MyControl));
         public Choice Choice4
         {
              get { return (Choice)GetValue(Choice4Property); }
              set { SetValue(Choice4Property, value); }
         }

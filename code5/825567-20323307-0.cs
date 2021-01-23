    public class LanguageHelper : DependencyObject {
      public static DependencyProperty Hompage_subheadingProperty =  
      DependencyProperty.Register("Homepage_subheading", typeof(string), typeof(LanguageHelper));
      public String Homepage_subheading {
         get { return (string) GetValue(Homepage_subheadingProperty);}
         set { SetValue(Homepage_subheadingProperty, value);}
      }
    }

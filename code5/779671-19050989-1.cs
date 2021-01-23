    public class MyButton : Button
    {
      public static readonly DependencyProperty IconContentProperty =
        DependencyProperty.Register("IconContent", typeof (string), typeof (ButtonWithIcon),   new PropertyMetadata(default(Icon)));
      public string IconContent
      {
        get { return (string) GetValue(IconContentProperty); }
        set { SetValue(IconContentProperty, value); }
      }
    }

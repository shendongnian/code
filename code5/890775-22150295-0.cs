    public static readonly DependencyProperty NTextProperty = DependencyProperty.Register(
           "NText", typeof (string), typeof (TextboxCC), new PropertyMetadata(default(string)));
       public string NText
       {
           get { return (string) GetValue(NTextProperty); }
           set { SetValue(NTextProperty, value); }
       }

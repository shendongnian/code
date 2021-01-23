    public static readonly DependencyProperty TextProperty = 
    DependencyProperty.Register("Text", typeof(string), typeof(Button));
    public string Text
    {
        get
        {
            return this.GetValue(TextProperty) as string;
        }
        set
        {
            this.SetValue(TextProperty, value);
        }
    }

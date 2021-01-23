    /// <summary>
    /// Provides a bindable text property to the user control
    /// </summary>
    public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(UserControl1), new PropertyMetadata("", onTextPropertyChanged));
    
    /// <summary>
    /// optional static call back handler when the property changed
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    static void onTextPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        var obj = o as UserControl1;
        if (obj == null)
            return;
    
        //TODO: Changed...
    }
    
    /// <summary>
    /// Gets \ sets the text
    /// </summary>
    public string Text
    {
        get { return (string)this.GetValue(TextProperty); }
        set
        {
            if (this.Text != value)
                this.SetValue(TextProperty, value);
        }
    }

    public static readonly DependencyProperty RichTextBlockItemProperty = DependencyProperty.RegisterAttached(
      "RichTextBlockItem",
      typeof(object),
      typeof(RichTextBlock),
      new PropertyMetadata(null, RichTextBlockItemChanged)
    );
    // Don't forget this!
    public static object GetRichTextBlockItem(DependencyObject obj)
    {
        return (object)obj.GetValue(RichTextBlockItemProperty);
    }
    // And this!
    public static void SetRichTextBlockItem(DependencyObject obj, object value)
    {
       obj.SetValue(RichTextBlockItemProperty, value);
    }
    public void RichTextBlockItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // Here you can do whatever you wish. This method will fire when the item is bound.
        // d is the RichTextBlock object.
        // e.NewValue is the value that was just bound.
        // So, from here you can dynamically add your Runs/Images/etc
    }

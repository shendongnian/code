    public static readonly DependencyProperty RichTextBlockItemProperty = DependencyProperty.RegisterAttached(
      "RichTextBlockItem",
      typeof(object),
      typeof(RichTextBlock),
      new FrameworkPropertyMetadata(null, RichTextBlockItemChanged)
    );
    public void RichTextBlockItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // Here you can do whatever you wish. This method will fire when the item is bound.
        // d is the RichTextBlock object.
        // e.NewValue is the value that was just bound.
        // So, from here you can dynamically add your Runs/Images/etc
    }

    public static readonly DependencyProperty TextProperty =
        TextBlock.TextProperty.AddOwner(typeof(ccTestFigure), new FrameworkPropertyMetadata(propertyChangedCallback: OnTextChanged));
    private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ((ccTestFigure)sender).UpdateText();
    }
    private void UpdateText() 
    {
        var typeface = new Typeface(
                        FontFamily,
                        FontStyle,
                        FontWeights.Normal,
                        FontStretches.Normal);
       ft  = new FormattedText(
               Text,
               System.Threading.Thread.CurrentThread.CurrentCulture,
               FlowDirection.LeftToRight,
               typeface,
               FontSize,
               Foreground);
    }
    public ccTestFigure()
    {
    }

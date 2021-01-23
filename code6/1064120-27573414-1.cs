    static ccTestFigure()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ccTestFigure), new FrameworkPropertyMetadata(OnTextChanged));
    }
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

    public class ExtendedTextBlock : TextBlock
    {
        public string RightAlignedText
        {
            get { return (string)GetValue(RightAlignedTextProperty); }
            set { SetValue(RightAlignedTextProperty, value); }
        }
        public static readonly DependencyProperty RightAlignedTextProperty =
            DependencyProperty.Register("RightAlignedText", typeof(string), typeof(ExtendedTextBlock), new PropertyMetadata(SetText));
        public string LeftAlignedText
        {
            get { return (string)GetValue(LeftAlignedTextProperty); }
            set { SetValue(LeftAlignedTextProperty, value); }
        }
        public static readonly DependencyProperty LeftAlignedTextProperty =
            DependencyProperty.Register("LeftAlignedText", typeof(string), typeof(ExtendedTextBlock), new PropertyMetadata(SetText));
        public static void SetText(object sender, DependencyPropertyChangedEventArgs args)
        {
            SetText((ExtendedTextBlock)sender);
        }
        public static void SetText(ExtendedTextBlock owner)
        {
            if (owner.ActualWidth == 0)
                return;
            // helper function to get the width of a text string
            Func<string, double> getTextWidth = text =>
            {
                var formattedText = new FormattedText(text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
                    new Typeface(owner.FontFamily, owner.FontStyle, owner.FontWeight, owner.FontStretch),
                    owner.FontSize,
                    Brushes.Black);
                return formattedText.Width;
            };
            // calculate the space needed to fill in
            double spaceNeeded = owner.ActualWidth - getTextWidth(owner.LeftAlignedText ?? "") - getTextWidth(owner.RightAlignedText ?? "");
            // get the width of an empty space (have to cheat a bit since the width of an empty space returns zero)
            double spaceWidth = getTextWidth(" .") - getTextWidth(".");
            int spaces = (int)Math.Round(spaceNeeded / spaceWidth);
            owner.Text = owner.LeftAlignedText + new string(Enumerable.Repeat(' ', spaces).ToArray()) + owner.RightAlignedText;
        }
        public ExtendedTextBlock()
        {
            SizeChanged += (sender, args) => SetText(this);
        }
    }

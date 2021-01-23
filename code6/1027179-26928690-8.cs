    public class FixedLabelRenderer : ViewRenderer<FixedLabel, UILabel>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FixedLabel> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(new UILabel(RectangleF.Empty) {
                BackgroundColor = Element.BackgroundColor.ToUIColor(),
                AttributedText = ((FormattedString)Element.Text).ToAttributed(Element.Font, Element.TextColor),
                LineBreakMode = ConvertLineBreakMode(Element.LineBreakMode),
                TextAlignment = ConvertAlignment(Element.XAlign),
                Lines = 0,
            });
            BackgroundColor = Element.BackgroundColor.ToUIColor();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
                Control.AttributedText = ((FormattedString)Element.Text).ToAttributed(Element.Font, Element.TextColor);
            base.OnElementPropertyChanged(sender, e);
        }
        // copied from iOS LabelRenderer
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (Control == null)
                return;
            Control.SizeToFit();
            var num = Math.Min(Bounds.Height, Control.Bounds.Height);
            var y = 0f;
            switch (Element.YAlign) {
                case TextAlignment.Start:
                    y = 0;
                    break;
                case TextAlignment.Center:
                    y = (float)(Element.FixedHeight / 2 - (double)(num / 2));
                    break;
                case TextAlignment.End:
                    y = (float)(Element.FixedHeight - (double)num);
                    break;
            }
            Control.Frame = new RectangleF(0, y, (float)Element.FixedWidth, num);
        }
        static UILineBreakMode ConvertLineBreakMode(LineBreakMode lineBreakMode)
        {
            switch (lineBreakMode) {
                case LineBreakMode.TailTruncation:
                    return UILineBreakMode.TailTruncation;
                case LineBreakMode.WordWrap:
                    return UILineBreakMode.WordWrap;
                default:
                    return UILineBreakMode.Clip;
            }
        }
        static UITextAlignment ConvertAlignment(TextAlignment xAlign)
        {
            switch (xAlign) {
                case TextAlignment.Start:
                    return UITextAlignment.Left;
                case TextAlignment.End:
                    return UITextAlignment.Right;
                default:
                    return UITextAlignment.Center;
            }
        }
    }

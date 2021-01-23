    // Put this in your iOS project
    [assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
    namespace MyNamespace
    { 
        public class CustomLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
                // Make sure control is not null
                var label = (CustomLabel)Element;
                if (label == null || Control == null)
                {
                    return;
                }
                var labelString = new NSMutableAttributedString(label.Text);
                var paragraphStyle = new NSMutableParagraphStyle { LineSpacing = (nfloat)label.LineHeight };
                var style = UIStringAttributeKey.ParagraphStyle;
                var range = new NSRange(0, labelString.Length);
                labelString.AddAttribute(style, paragraphStyle, range);
                Control.AttributedText = labelString;
            }
        }
    }

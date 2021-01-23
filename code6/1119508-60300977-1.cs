    // Put this in your iOS project
    [assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
    namespace App.iOS.Components
    {
        public class CustomLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
                var label = (CustomLabel)Element;
                if (label == null || Control == null)
                {
                    return;
                }
                double fontSize = label.FontSize;
                //iOS LineSpacing is measured in dp, as the FontSize. So, if we need a LineSpacing of 2, 
                //this LineSpacing must be set to the same value of the FontSize
                nfloat lineSpacing = ((nfloat)label.LineHeight * (nfloat)fontSize) - (nfloat)fontSize;
                if (lineSpacing > 0)
                {
                    var labelString = new NSMutableAttributedString(label.Text);
                    var paragraphStyle = new NSMutableParagraphStyle { LineSpacing = lineSpacing };
                    var style = UIStringAttributeKey.ParagraphStyle;
                    var range = new NSRange(0, labelString.Length);
                    labelString.AddAttribute(style, paragraphStyle, range);
                    Control.AttributedText = labelString;
                }
            }
        }
    }

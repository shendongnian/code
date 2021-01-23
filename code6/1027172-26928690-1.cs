    public class FixedLabelRenderer : ViewRenderer
    {
        public TextView TextView;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            var label = Element as FixedLabel;
            TextView = new TextView(Context);
            TextView.Text = label.Text;
            TextView.TextSize = (float)label.Font.FontSize;
            TextView.Gravity = ConvertXAlignment(label.XAlign) | ConvertYAlignment(label.YAlign);
            TextView.SetSingleLine(label.LineBreakMode != LineBreakMode.WordWrap);
            if (label.LineBreakMode == LineBreakMode.TailTruncation)
                TextView.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
            SetNativeControl(TextView);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
                TextView.Text = (Element as FixedLabel).Text;
            base.OnElementPropertyChanged(sender, e);
        }
        static GravityFlags ConvertXAlignment(Xamarin.Forms.TextAlignment xAlign)
        {
            switch (xAlign) {
                case Xamarin.Forms.TextAlignment.Center:
                    return GravityFlags.CenterHorizontal;
                case Xamarin.Forms.TextAlignment.End:
                    return GravityFlags.End;
                default:
                    return GravityFlags.Start;
            }
        }
        static GravityFlags ConvertYAlignment(Xamarin.Forms.TextAlignment yAlign)
        {
            switch (yAlign) {
                case Xamarin.Forms.TextAlignment.Center:
                    return GravityFlags.CenterVertical;
                case Xamarin.Forms.TextAlignment.End:
                    return GravityFlags.Bottom;
                default:
                    return GravityFlags.Top;
            }
        }
    }

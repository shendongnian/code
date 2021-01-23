    // Put this in your Android project
    [assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
    namespace App.Droid.Components
    {
        public class CustomLabelRenderer : LabelRenderer
        {
            protected CustomLabel CustomLabel { get; private set; }
            public CustomLabelRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement == null)
                {
                    this.CustomLabel = (CustomLabel)this.Element;
                }
                double lineSpacing = this.CustomLabel.LineHeight;
                if (lineSpacing > 0)
                {
                    this.Control.SetLineSpacing(1f, (float)lineSpacing);
                    this.UpdateLayout();
                }
            }
        }
    }

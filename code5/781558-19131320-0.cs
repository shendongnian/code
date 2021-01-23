        public class MyControl : Control
        {
            private bool _BorderShadow;
            private BorderStyle _BorderStyle;
            public bool BorderShadow
            {
                get { return _BorderShadow; }
                set
                {
                    if(_BorderShadow != value)
                    {
                        _BordeShadow = value;
                        ApplyBorderShadowIfNeeded();
                    }
                }
            }
            public BorderStyle BorderStyle
            {
                get { return _BorderStyle; }
                set
                {
                    if(_BorderStyle != value)
                    {
                        _BorderStyle = value;
                        ApplyBorderShadowIfNeeded();
                    }
                }
            }
            private void ApplyBorderShadowIfNeeded()
            {
                 if(_BorderStyle == BorderStyle.FixedSingle
                    && _BorderShadow)
                 {
                      // ToDo: Apply the shadow to the border.
                 }
            }
        }

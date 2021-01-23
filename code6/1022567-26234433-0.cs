     public class UGLinkLabel : LinkLabel
        {
            private bool _displayFocusCues = true;
    
            protected override bool ShowFocusCues
            {
                get
                {
                    return _displayFocusCues;
                }
            }
    
            public bool DisplayFocusCues
            {
                get
                {
                    return _displayFocusCues;
                }
                set
                {
                    _displayFocusCues = value;
                }
            }
        }

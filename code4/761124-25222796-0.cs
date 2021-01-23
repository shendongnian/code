            // Property variable
            private bool _MenuStripEnabled = true;
            // Custom property
            public bool MenuStripEnabled
            {
                get { 
                   return _MenuStripEnabled; 
                }
                set { 
                   _MenuStripEnabled = value; 
                   this.MainMenuStripControl.Enabled = value;
                }
            }

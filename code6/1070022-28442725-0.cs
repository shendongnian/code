        class SilentTextBox : TextBox
        {
            // if true, than the TextChanged event should not be thrown
            private bool Silent { get; set; }
            public string SilentText
            {
                set
                {
                    Silent = true;
                    Text = value;
                    Silent = false;
                }
            }
            protected override void OnTextChanged(EventArgs e)
            {
                // raise event only if the control is in non-silent state
                if (!Silent)
                {
                    base.OnTextChanged(e);
                }
            }
        }

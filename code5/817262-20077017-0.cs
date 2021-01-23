        private void Reset(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown nud = c as NumericUpDown;
                    nud.Value = nud.Minimum;
                }
                else if (c.HasChildren)
                { 
                    Reset(c);
                }
            }
        }

        public void objChecked(Control c, bool enabled)
        {
            RadioButton x = c as RadioButton;
            if(x == null)
                throw new ArgumentException();
            if (x.InvokeRequired)
            {
                BeginInvoke(new MyDelegate(delegate()
                {
                    x .Checked = enabled;
                }));
            }
            else
            {
                x.Checked = enabled;
            }
        }

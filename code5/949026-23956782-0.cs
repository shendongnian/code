        private class WedgeForm : Form
        {
            public override string Text { get { return text; } set { text = value; } }
            string text = string.Empty;
            private TextBox tb;
            public WedgeForm()
            {
                InitializeControls();
                Activated += (s, e) => { tb.Focus(); };
                FormClosing += (s, e) => { this.Text = tb.Text; };
            }
            private void InitializeControls()
            {
                tb = new TextBox();
                tb.Name = "tb";
                tb.TabIndex = 0;
                tb.AcceptsReturn = true;
                tb.AcceptsTab = true;
                tb.Multiline = true;
                tb.Dock = DockStyle.Fill;
                this.Controls.Add(tb);
            }
        }

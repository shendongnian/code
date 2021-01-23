        public Form1()
        {
            InitializeComponent();
            TextBox tb = new TextBox();
            tb.Name = "dynamic";
            tb.Text = "Text dynamic";
            tabControl1.TabPages[1].Controls.Add(tb);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (sender as TabControl);
            switch (tc.SelectedIndex)
            {
                case 0:
                    
                    break;
                case 1:
                    Control[] temp = tc.TabPages[1].Controls.Find("dynamic", true);
                    if (temp.Length == 1)
                    {
                        (temp[0] as TextBox).Focus();
                    }
                    break;
            }
        }

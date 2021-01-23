        public System.Windows.Forms.TextBox AddNewTextBox()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            this.Controls.Add(txt);
            txt.Top = cLeft * 25;
            txt.Left = 100; 
            txt.Text = "TextBox " + this.cLeft.ToString();
            cLeft = cLeft + 1;
            txt.AcceptsReturn = true;
            KeyEventArgs e;
            if (txt.Text != null && e.KeyCode == Keys.Enter)
            {
                txt.Visible = false;
            }
            return txt;

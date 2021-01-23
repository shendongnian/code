        public void txtExtra_TextChanged(object sender, EventArgs e)
        {
            for (int a = 1; a <= int.Parse(txtExtra.Text); a++)
            {
                TextBox txt = new TextBox();
                txt.ID = "txtquestion" + a;
                txt.Text = "Some text"; // Set some text here
                pholder.Controls.Add(txt);
            }
        }

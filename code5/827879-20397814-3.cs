    protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                for (int i = 0; i < Convert.ToInt16(TextBox1.Text); i++)
                {
                    TextBox tb1 = new TextBox();
                    tb1.ID = "newTB" + i.ToString();
                    form1.Controls.Add(tb1);
                }
            }   
        }

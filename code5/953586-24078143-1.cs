    protected void Button_plus_Click(object sender, EventArgs e)
    {
    int tal1 = Convert.ToInt32(TextBox_Tal1.Text);
    int tal2 = Convert.ToInt32(TextBox_Tal2.Text);
    Label_plus.Text = (tal1 + tal2).ToString();        
    }

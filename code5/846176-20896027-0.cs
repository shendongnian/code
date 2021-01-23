    protected void Button1_Click(object sender, EventArgs e)
    {
    
    for (int i = 1; i <= 20; i++)
    {
    
    TextBox temp = Page.FindControl("TextBox" + i) as TextBox;temp.Text = "";
    }
    
    }

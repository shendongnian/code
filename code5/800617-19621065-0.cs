    protected void btnSave1_Click(object sender, EventArgs e)
    {
         GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
         TextBox TextBox1 = row.FindControl("TextBox1") as TextBox; 
          //Access TextBox1 here.
          string myString = TextBox1.Text;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox textBox1 = (TextBox)e.Row.FindControl("TextBox1");
                TextBox textBox2 = (TextBox)e.Row.FindControl("TextBox2");
                textBox1.Attributes.Add("onkeyup", "cal('" + textBox1.ClientID + "','" + textBox2.ClientID + "')");
                textBox1.Attributes.Add("onkeypress", "cal('" + textBox1.ClientID + "','" + textBox2.ClientID + "')");
              
            }
        }

    protected void SomeMethod(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Label1.Text = id;
            
        }

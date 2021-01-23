    protected void AddButton_Click(object sender, EventArgs e)
    {
        // Insert new user
        using (var db = new Database("DatabaseConnectionString"))
        {
            db.Insert("User", "Id", true,
                new
                {
                    Name = NameTextBox.Text,
                    Gender = GenderDropDownList.SelectedValue,
                    MemberNumber = MemberNumberTextBox.Text,
                    Password = PasswordTextBox.Text
                });
        }
    
        // Refresh the data in the grid
        GridView1.DataBind();
        GridView2.DataBind();
        GridView3.DataBind();
    }

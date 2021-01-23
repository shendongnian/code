    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Edit")
        {
            //Get row index stored in command argument
            int index = Convert.ToInt32(e.CommandArgument);  
            //Find the row where button is clicked
            GridViewRow clickedRow = CustomersGridView.Rows[index];
            //Find the textbox in that row where cell index location is 2
            TextBox myTextBox = (TextBox)clickedRow.Cells[2].FindControl("TextBoxName");
            //Now you can get the string text of your textbox
            string text = myTextBox.Text;
        }
    }

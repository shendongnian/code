    void CustomersGridView_RowDeleting
        (Object sender, GridViewDeleteEventArgs e)
    {
        TableCell cell = CustomersGridView.Rows[e.RowIndex].Cells[2];
        if (cell.Text == "Beaver")
        {
            e.Cancel = true;
            Message.Text = "You cannot delete customer Beaver.";
        }
        else
        {
            Message.Text = "";
        }
    }  

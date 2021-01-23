    protected void CustomerSqlDataSource_Deleted(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows == 0)
        {
            DeleteLabel.Visible = true;
            DeleteLabel.Text = "This Customer cannot be deleted because it has orders";
        }
    }

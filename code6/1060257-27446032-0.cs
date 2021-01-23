    protected void CustomerSqlDataSource_Deleted(object sender, SqlDataSourceStatusEventArgs e)
    {
         try {
             if (e.ExceptionHandled == false)
             {
             e.Command.Cancel();
             DeleteLabel.Visible = true;
             DeleteLabel.Text = "This Customer cannot be deleted";
         }
         catch {
           // do your thing here when error occurs
         }
    }

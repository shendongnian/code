     protected override void OnClosed(EventArgs e)
        {
            if (sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Dispose();
                sqlConnection.Close();
            }
            base.OnClosed(e);
        }

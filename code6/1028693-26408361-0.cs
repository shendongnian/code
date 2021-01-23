    protected void editDelete(object sender, DirectEventArgs e)
    {
        using (
            var MyConnection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
        {
            MyConnection.Open();
            // Start a local transaction.
            using (var sqlTran = MyConnection.BeginTransaction())
            {
                try
                {
                    using(var MyCommand = MyConnection.CreateCommand())
                    {
                        MyCommand.CommandText = /* 3 queries removed to shorten code */;
                        MyCommand.CommandType = CommandType.Text;
                        MyCommand.Transaction = sqlTran;
                        SqlParameter p1 = new SqlParameter("@id", this.accountidEdit.Value);
                        MyCommand.Parameters.Add(p1);
                        MyCommand.ExecuteNonQuery();
                        sqlTran.Commit();
                    }
                    /* reload and notification calls removed to shorten code */
                }
                catch (Exception)
                {
                    X.Msg.Alert("Error", "Error.").Show();
                }
            }
        }
    }

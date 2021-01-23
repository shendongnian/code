    private void DoWork()
    {
        for (int i = 1; i <= sourceTable.Rows.Count - 1; i++)
        {
            string checkout;
            checkout = sourceTable.Rows[i].Field<string>(0);
            using (dest = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["local"].ConnectionString))
            {
                dest.Open();
                using (destcmd = new SqlCommand(checkout, dest))
                {
                    destcmd.ExecuteNonQuery();
                    dest.Close();
                    prcmail();
                    prcmessagecheck();
                    if (lblProgress.InvokeRequired)
                    {
                        lblProgress.Invoke(new ProgressCallback(SetProgressLabel), new object[] { i });
                    }
                    else
                    {
                        SetProgressLabel(i);
                    }
                    Thread.Sleep(1000); // I changed this from 10000 to 1000 (10 seconds down to 1 second)
                }
            }
        }
    }

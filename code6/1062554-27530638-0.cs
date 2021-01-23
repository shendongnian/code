    for (int i = 1; i <= sourceTable.Rows.Count - 1; i++)
    {
    
    string checkout;
    checkout= sourceTable.Rows[i].Field<string>(0);
    dest = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["local"].ConnectionString);
    dest.Open();
    destcmd = new SqlCommand(checkout, dest);
    destcmd.ExecuteNonQuery();
    dest.Close();
    prcmail();
    prcmessagecheck();
    lblProgress.Text = "Hello World"+i;
    Application.DoEvents();
    }

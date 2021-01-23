    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.slMonth.Items.Count <= 0)
            for (int i = 1; i <= 12; i++)
            {
                slMonth.Items.Add(new ListItem(
                    System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                    i.ToString()
                ));
            }
        ListItem li = new ListItem();
        li.Text = "-Select Month-";
        li.Value = "0";
        slMonth.Items.Insert(0, li);
        
        slYear.Items.Insert(0, "-Select Year-");
        int index = 1;
        for (int Year = 2000; Year <= DateTime.Now.Year; Year++)
        {
            ListItem liYear = new ListItem(Year.ToString(), Year.ToString());
            slYear.Items.Insert(index, liYear);
            index++;
        }
    }
    protected void Update_Spend(object sender, System.EventArgs e)
    {
        SqlConnection SQLConn = null;
        try
        {
            SQLConn = new SqlConnection(@"Data Source=./;Database=ACQ;User Id=sa;Password=PWD;");
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.CommandText = "UpdatetblRPT_Spend";
            cmdUpdate.Connection = SQLConn;
            cmdUpdate.Parameters.Add("@Month", SqlDbType.Int).Value = slMonth.SelectedValue;
            cmdUpdate.Parameters.Add("@Year", SqlDbType.Int).Value = slYear.SelectedValue;
            SQLConn.Open();
            cmdUpdate.ExecuteNonQuery();
            LastMsg.Text = "Spend updated successfully.";
        }
        catch (Exception ex)
        {
        }
        finally
        {
            SQLConn.Close();
        }
    }

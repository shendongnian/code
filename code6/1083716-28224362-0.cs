    private string SqlSelection()
    {
       string sql = null;
       if (comboBox1.Text == "All" & comboBox2.Text == "All")
       {
         sql = "SELECT stationID, LocationName, plandate, username, status FROM dbo.joblist WHERE status in ('New','Hold')";
       }
       else if (comboBox1.Text == "All" & comboBox2.Text == "@status")    }
       ...
       return sql;
    }

    private string SQLSelection()
    {
    private String SQL = null;
    if (comboBox1.Text == "All" & comboBox2.Text == "All")
    {
        SQL = "SELECT stationID, LocationName, plandate, username, status FROM dbo.joblist WHERE status in ('New','Hold')";
    }
    else if (comboBox1.Text == "All" & comboBox2.Text == "@status")
    {
        SQL = "SELECT stationID, LocationName, plandate, username, status FROM dbo.joblist WHERE status = @status";
    }
    else if (comboBox1.Text == "@username" & comboBox2.Text == "All")
    {
         SQL = "SELECT stationID, LocationName, plandate, username, status FROM dbo.joblist WHERE status = @username";
    }
    else
    {
        SQL = "SELECT stationID, LocationName, plandate, username, status  FROM dbo.joblist WHERE username = @username and status = @status";
    }
    if(SQL != null)
        return SQL;
    else 
       return "any phrase you want ";
}

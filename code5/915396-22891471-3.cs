    private void Window_ContentRendered(object sender, EventArgs e)
    {
        string Test1Sql = "Test1 SQL query"; // stored separately
        string Test2Sql = "Test2 SQL query"; // stored separately
        MyTextBlock1.Text = ReturnNumberFromSQL(Test1Sql).ToString();
        MyTextBlock2.Text = ReturnNumberFromSQL(Test2Sql).ToString();
    }
    public int ReturnNumberFromSQL(string StrQuery)
    {
        return 777;
    }

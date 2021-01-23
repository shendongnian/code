    [TestMethod]
    public void TestMethod1()
    {
        var connStr = "Driver={SQL Server};server=.\\sqlexpress;uid=myid;pwd=password;";
        var builder = new DbConnectionStringBuilder();
        builder.ConnectionString = connStr;
        builder.Remove("Driver");
        connStr = builder.ConnectionString;
        Assert.AreEqual("server=.\\sqlexpress;uid=myid;pwd=password", connStr);
    }

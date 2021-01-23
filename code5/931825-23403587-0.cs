    string queryString1 = "select top 3 YP.utblYPBusinessInstanceInfoKeys.BusinessID,
                                        YP.utblYPBusinessInstanceInfoKeys.BusinessName,
                                        YP.utblYPBusinessInstanceInfoKeys.LastUpdatedByDate as GeneraliseDate
                           from  YP.utblYPBusinessInstanceInfoKeys
                           order by  GeneraliseDate desc"
    
    string queryString2 = "select top 3 YP.utblYPBusinessInstanceInfoKeys.BusinessID,
                                        YP.utblYPBusinessInstanceInfoKeys.BusinessName,
                                        YP.utblYPBusinessInstanceInfoKeys.CreatedByDate as GeneraliseDate
                            from  YP.utblYPBusinessInstanceInfoKeys
                            order by  GeneraliseDate desc"
    
    string queryString = queryString1 + Environment.NewLine + queryString2;
    
    
    DataSet dataSet = new DataSet();
    
    var connection = new SqlConnection("TODO:put connection string here");
    connection.Open();
    using(connection)
    {
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection); 
        adapter.Fill(dataSet);
    }
    
    // here you go
    foreach(DataTable table in dataSet.Tables)
    {
        Console.WriteLine(table.Name);
    }

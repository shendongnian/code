    2)
    private string sql = "SELECT ID, FirstName, LastName, Age FROM Person WHERE ....."
    3)
    public SQLReader something
    {
    return this.DataReader(sql);
    }
    4)
    public Dataset SomeData
    {
    Dataset data = new DataSet()
    try
    {
     this.DataAdapter(sql).Fill(data, "Person");
    }
     catch
     {
     data = null;
     }
     return data;
    }
    }
    }

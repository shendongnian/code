    public MyDataSet Load(string path)
    {
        MyDataSet ds = new MyDataSet();
        ds.ReadXml(path);
        return ds;
    }
    public void SaveChanges(MyDataSet ds, string path )
    {
        //PingSettings.AcceptChanges();
        ds.WriteXml(path);
    }

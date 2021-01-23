    public MyDataSet Load(string path)
    {
        MYXml ds = new MYXml();
        ds.ReadXml(path);
        return ds;
    }
    public void SaveChanges(MYXml ds, string path )
    {
        // ds.AcceptChanges();
        ds.WriteXml(path);
    }

    public void WriteToFile(string ProductName)
    {
        //Get Data from DB and stored in "ProductName"
        using (var tw = new StreamWriter(path11, true))
        {
            tw.WriteLine(ProductName+"@"+DateTime.Now.ToString());
        }
    }

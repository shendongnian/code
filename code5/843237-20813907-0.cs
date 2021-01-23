    public double? ProcessFileAndReturnNumberFromStream()
    {
        string fileName = "Test.txt";
        Data dat = new Data();
        using (StreamReader sr = new StreamReader(fileName))
        {
            return dat.GetNumberFromStream(sr);  
        }
     }

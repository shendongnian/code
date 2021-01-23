    public double[] loadData()
    {
        XDocument loadedData = XDocument.Load("XMLFILE1.xml");
        return (from query in loadedData.Descendants("ScoreData")
                     select (Double)query.Element("HS")).ToArray();
    }
                   

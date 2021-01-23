    // You could *consider* making this an extension method
    public static DataSet ToDataSetOrNull(XElement source)
    {
        if (source == null)
        {
            return null;
        }
        DataSet result = new DataSet();
        result.ReadXml(source.CreateReader(), XmlReadMode.Auto);
        return result;
    }

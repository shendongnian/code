    It may help for you:
     public DataTable ConvertXMLToDT(string xml)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new XmlTextReader(new StringReader(xml)));
            return ds.Tables[0];
        }

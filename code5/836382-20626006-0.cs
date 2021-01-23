    private void SerializeDataSet(DataSet ds, string filename){
        XmlSerializer ser = new XmlSerializer(typeof(DataSet));    
        TextWriter writer = new StreamWriter(filename);
        ser.Serialize(writer, ds);
        writer.Close();
    }

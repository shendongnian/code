    public DataTable ReadXml(string xmlString)
    {
        // Create the DataTable
        DataTable dt = new DataTable();
        try
        {
             //Create the columns with coresponding names
             dt.Columns.Add("CarId", typeOf(int));
             dt.Columns.Add("Make" typeOf(string));
             dt.Columns.Add("Model" typeOf(string));
             dt.Columns.Add("Year" typeOf(int));
             
             //Using ReadXml to populate the table
             dt.ReadXml(xmlString);
             //Return the table
             return dt;
        }
        catch (Exception ex)
        {
            //throw some exception
        }
    }

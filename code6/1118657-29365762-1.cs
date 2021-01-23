    private static string ConvertDataTableToXML(DataTable dtBuildSQL)    
    {    
        DataSet dsBuildSQL = new DataSet();    
        StringBuilder sbSQL;    
        StringWriter swSQL;    
        string XMLformat;    
        sbSQL = new StringBuilder();    
        swSQL = new StringWriter(sbSQL);
    
        dsBuildSQL.Merge(dtBuildSQL, true, MissingSchemaAction.AddWithKey);    
        dsBuildSQL.Tables[0].TableName = “Table”;
    
        foreach (DataColumn col in dsBuildSQL.Tables[0].Columns)    
        {
            col.ColumnMapping = MappingType.Attribute;
        }
    
        dsBuildSQL.WriteXml(swSQL, XmlWriteMode.WriteSchema);
        XMLformat = sbSQL.ToString();
        return XMLformat;    
    }

    using (XmlWriter xmlWriter = XmlWriter.Create(@"\\yourfilePath.xml"))
    {
        xmlWriter.WriteStartElement("root");
        xmlWriter.WriteStartElement("Products");
        xmlWriter.WriteElementString("totalcount", dt.Rows.Count.ToString());
        foreach (DataRow dataRow in dt.Rows)
        {
          xmlWriter.WriteStartElement("Product");
          foreach (DataColumn dataColumn in dt.Columns)
          {
              xmlWriter.WriteElementString(dataColumn.ColumnName, dataRow[dataColumn].ToString());
          }
          xmlWriter.WriteEndElement();
        }
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndElement();
     }

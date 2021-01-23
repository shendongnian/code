       public static string ToHtmlTable(this DataTable t,string cssClass="",string id=null,
                bool includeTHead=true,bool includeTBody=true,bool includeFooter=false,string trIDCol=null)
            {
                MemoryStream ms = new MemoryStream();
                XmlWriter x = new XmlTextWriter(ms, Encoding.Default);
                x.WriteStartElement("table");
                x.WriteAttributeString("class", cssClass);
                if (id != null)
                {
                    x.WriteAttributeString("id", id);
                    
                }
    
                x.WriteNewline(); x.WriteNewline();
                if (includeTHead)
                {
                    x.WriteStartElement("thead");
                }
                x.WriteStartElement("tr");
             
                foreach (DataColumn dc in t.Columns)
                {
                    x.WriteElementString("th", dc.ColumnName);
                    
                }
                x.WriteEndElement();
    
                if (includeTHead)
                {
                    x.WriteEndElement();
                }
    
                x.WriteNewline(); 
                x.WriteNewline();
                InsertTableRows(t, x, includeTBody,trIDCol);
                if (includeFooter)
                {
                    x.WriteStartElement("tfoot");
                    x.WriteStartElement("tr");
                    foreach (DataColumn dc in t.Columns)
                    {
                        x.WriteElementString("th", dc.ColumnName);
    
                    }
                    x.WriteEndElement();
                    x.WriteEndElement();
                }
                    
    
                x.WriteEndElement();
                x.Flush();
                return StreamUtils.StreamToString(ms);
            } 

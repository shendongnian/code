        public static void writeDropDownOptionHTML(HtmlTextWriter writer, string tablename, string id_col, string value_col)
                {
                    DataTable dt1 = BAL.setDropDown(tablename, id_col, value_col);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, row[0].ToString());
                            writer.RenderBeginTag(HtmlTextWriterTag.Option);
        
                            writer.Write(row[1].ToString());
                            writer.RenderEndTag();
                        }
                    }
                }
    
    public static string writeWalkReverseTableData(DataTable dt1)
            {
                StringWriter stringwriter = new StringWriter();
                HtmlTextWriter writer = new HtmlTextWriter(stringwriter);
    
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
    
                        writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);
                        writer.RenderBeginTag(HtmlTextWriterTag.Select);
                        writeDropDownOptionHTML(writer, "xyz","abc","def"); 
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                }
                return stringwriter.ToString();
            }

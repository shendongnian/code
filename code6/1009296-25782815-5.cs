         void export_Click(object sender, EventArgs e){
            MemoryStream ms = ExportDataTableToWorksheet(ds, ds2, true);
            byte[] bytesInStream = ms.ToArray(); 
           
            string filename = "export.xls";
         
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename="+filename);
            Response.AddHeader("Content-Type", "application/Excel");
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("Content-Length", bytesInStream.Length.ToString());
            Response.BinaryWrite(bytesInStream);
            Response.End();       
        }
        public static MemoryStream ExportDataTableToWorksheet(DataSet ds)
        {
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            // <?xml version="1.0"?>
            writer.WriteStartDocument();
            // <?mso-application progid="Excel.Sheet"?>
            writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
            // <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet >"
            writer.WriteStartElement("Workbook", "urn:schemas-microsoft-com:office:spreadsheet");
            // Namespace definitions
            writer.WriteAttributeString("xmlns", "o", null, "urn:schemas-microsoft-com:office:office");
            writer.WriteAttributeString("xmlns", "x", null, "urn:schemas-microsoft-com:office:excel");
            writer.WriteAttributeString("xmlns", "ss", null, "urn:schemas-microsoft-com:office:spreadsheet");
            writer.WriteAttributeString("xmlns", "html", null, "http://www.w3.org/TR/REC-html40");
            // <DocumentProperties xmlns="urn:schemas-microsoft-com:office:office">
            writer.WriteStartElement("DocumentProperties", "urn:schemas-microsoft-com:office:office");
            // Documentattributes Author, Date, Company
            writer.WriteElementString("Author", Environment.UserName);
            writer.WriteElementString("LastAuthor", Environment.UserName);
            writer.WriteElementString("Created", DateTime.Now.ToString("u") + "Z");
            writer.WriteElementString("Company", "Unknown");
            writer.WriteElementString("Version", "11.8122");
            // </DocumentProperties>
            writer.WriteEndElement();
            // <ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
            writer.WriteStartElement("ExcelWorkbook", "urn:schemas-microsoft-com:office:excel");
            // Workbook-Preferences
            writer.WriteElementString("WindowHeight", "13170");
            writer.WriteElementString("WindowWidth", "17580");
            writer.WriteElementString("WindowTopX", "120");
            writer.WriteElementString("WindowTopY", "60");
            writer.WriteElementString("ProtectStructure", "False");
            writer.WriteElementString("ProtectWindows", "False");
            // </ExcelWorkbook>
            writer.WriteEndElement();
            // <Styles>
            writer.WriteStartElement("Styles");
            // <Style ss:ID="Default" ss:Name="Normal">
            writer.WriteStartElement("Style");
            writer.WriteAttributeString("ss", "ID", null, "Default");
            writer.WriteAttributeString("ss", "Name", null, "Normal");
            // <Alignment ss:Vertical="Bottom"/>
            writer.WriteStartElement("Alignment");
            writer.WriteAttributeString("ss", "Vertical", null, "Bottom");
            writer.WriteEndElement();
            // Verbleibende Sytle-Eigenschaften leer schreiben
            writer.WriteElementString("Borders", null);
            writer.WriteElementString("Font", null);
            writer.WriteElementString("Interior", null);
            writer.WriteElementString("NumberFormat", null);
            writer.WriteElementString("Protection", null);
            // </Style>
            writer.WriteEndElement();
            // </Styles>
            writer.WriteEndElement();
            // <Worksheet ss:Name="xxx">
            writer.WriteStartElement("Worksheet");
            writer.WriteAttributeString("ss", "Name", null, "export");
            // <Table ss:ExpandedColumnCount="2" ss:ExpandedRowCount="3" x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="60">
            writer.WriteStartElement("Table");
            // setting the column count
            writer.WriteAttributeString("ss", "ExpandedColumnCount", null, "1");
            else writer.WriteAttributeString("ss", "ExpandedRowCount", null, (ds.Tables[0].Rows.Count).ToString());
            writer.WriteAttributeString("x", "FullColumns", null, "1");
            writer.WriteAttributeString("x", "FullRows", null, "1");
            writer.WriteAttributeString("ss", "DefaultColumnWidth", null, "100");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                // <Row>
                writer.WriteStartElement("Row");
                // Alle Zellen der aktuellen Zeile durchlaufen
                writeCell(writer, (string)row["name"]);
                // </Row>
                writer.WriteEndElement();
            }
            // </Table>
            writer.WriteEndElement();
            // <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
            writer.WriteStartElement("WorksheetOptions", "urn:schemas-microsoft-com:office:excel");
            // pagesetup
            writer.WriteStartElement("PageSetup");
            writer.WriteStartElement("Header");
            writer.WriteAttributeString("x", "Margin", null, "0.4921259845");
            writer.WriteEndElement();
            writer.WriteStartElement("Footer");
            writer.WriteAttributeString("x", "Margin", null, "0.4921259845");
            writer.WriteEndElement();
            writer.WriteStartElement("PageMargins");
            writer.WriteAttributeString("x", "Bottom", null, "0.984251969");
            writer.WriteAttributeString("x", "Left", null, "0.78740157499999996");
            writer.WriteAttributeString("x", "Right", null, "0.78740157499999996");
            writer.WriteAttributeString("x", "Top", null, "0.984251969");
            writer.WriteEndElement();
            writer.WriteEndElement();
            // <Selected/>
            writer.WriteElementString("Selected", null);
            // <Panes>
            writer.WriteStartElement("Panes");
            // <Pane>
            writer.WriteStartElement("Pane");
            //
            writer.WriteElementString("Number", "1");
            writer.WriteElementString("ActiveRow", "1");
            writer.WriteElementString("ActiveCol", "1");
            // </Pane>
            writer.WriteEndElement();
            // </Panes>
            writer.WriteEndElement();
            // <ProtectObjects>False</ProtectObjects>
            writer.WriteElementString("ProtectObjects", "False");
            // <ProtectScenarios>False</ProtectScenarios>
            writer.WriteElementString("ProtectScenarios", "False");
            // </WorksheetOptions>
            writer.WriteEndElement();
            // </Worksheet>
            writer.WriteEndElement();
            // </Workbook>
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
            return ms;
        }
        /// <summary>
        /// Removes control characters and other non-UTF-8 characters
        /// </summary>
        /// <param name="inString">The string to process</param>
        /// <returns>A string with no control characters or entities above 0x00FD</returns>
        public static string RemoveTroublesomeCharacters(string input)
        {
            var isValid = new Predicate<char>(value =>
        (value >= 0x0020 && value <= 0xD7FF) ||
        (value >= 0xE000 && value <= 0xFFFD) ||
        value == 0x0009 ||
        value == 0x000A ||
        value == 0x000D);
            return new string(Array.FindAll(input.ToCharArray(), isValid));
        }
        static void writeCell(XmlTextWriter writer, string value)
        {
            // <Cell>
            writer.WriteStartElement("Cell");
            // <Data ss:Type="String">xxx</Data>
            writer.WriteStartElement("Data");
            writer.WriteAttributeString("ss", "Type", null, "String");
            // Zelleninhakt schreiben
            writer.WriteValue(value);
            // </Data>
            writer.WriteEndElement();
            // </Cell>
            writer.WriteEndElement();
        }

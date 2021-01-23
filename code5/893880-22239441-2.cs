     using (var writer = new StreamWriter(fileDialog.OpenFile(), Encoding.UTF8))
    		            {
    			            if (format == "XML")
    			            {
    				            writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
    				            writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
    				            writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\">");
    				            writer.WriteLine("<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
    				            writer.WriteLine("<Author></Author>");
    				            writer.WriteLine("<Created>" + DateTime.Now.ToLocalTime().ToLongDateString() + "</Created>");
    				            writer.WriteLine("<LastSaved>" + DateTime.Now.ToLocalTime().ToLongDateString() + "</LastSaved>");
    				            writer.WriteLine("<Company></Company>");
    				            writer.WriteLine("<Version>12.00</Version>");
    				            writer.WriteLine("</DocumentProperties>");
    
    				            if (showGroupHeaders)
    					            AddStyles(writer, groupDesc.Count());
    
    				            writer.WriteLine(
    					            "<Worksheet ss:Name=\"Silverlight Export\" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
    				            writer.WriteLine("<Table>");
    			            }
    
    			            writer.Write(text.ToString());
    			            if (format == "XML")
    			            {
    				            writer.WriteLine("</Table>");
    				            writer.WriteLine("</Worksheet>");
    				            writer.WriteLine("</Workbook>");
    			            }
    
    			            writer.Close();
    		            }
    

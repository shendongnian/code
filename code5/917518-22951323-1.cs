    HtmlElementCollection tables = this.WB.Document.GetElementsByTagName("table");
    
                foreach (HtmlElement TBL in tables)
                {
                    foreach (HtmlElement ROW in TBL.All)
                    {
    
                        foreach (HtmlElement CELL in ROW.All)
                        {
    
                            // Now you are looping through all cells in each table
    
                            // Here you could use CELL.InnerText to search for "Status" or "Approved"
                        }
                    }
                }

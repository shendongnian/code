    HtmlElementCollection tTABLES = this.webBrowser1.Document.GetElementsByTagName("table");
    
                foreach (HtmlElement TBL in tTABLES)
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

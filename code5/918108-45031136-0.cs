    List<string> test = new List<string>();
    try
            {
                HTML_Node.Get_HTML_Nodes($"{URL}", "//table[@class='Details']//tr").Result.ForEach(n =>
                {
                    List<string> values = n.ChildNodes.Where(cN => cN.NodeType == HtmlNodeType.Element).Select(e => e.InnerText.Trim().ToLower()).ToList();
                    
                    if (String.IsNullOrEmpty(values[0]))
                    {
                    // skip to the next node if there is no value 
                    }
                    else
                    {
                     // add the value [0 ] to your list 
                        test.Add(values[0]);
                            
                            
                    }
                });
           
            }
            catch (Exception ex)
            {
                throw;
            }
           return test ;

    string weight= "";
    string salesrate = "";
    
    public void button11_Click(object sender, EventArgs e)
    {
        weight = (ExtractNumbers(webBrowser1.Document.GetElementsByTagName("table")[2].GetElementsByTagName("td")[11].InnerText));
    }
    
    public void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        salesrate = (ExtractNumbers(this.webBrowser3.Document.GetElementsByTagName("table")[2].GetElementsByTagName("td")[17].InnerText)); 
    }
    
    public void timer9_Tick(object sender, EventArgs e)
    {
        try {
          var parsedSalesRate = Double.parse(salesrate);
          var parsedWeight = Double.parse(weight);
          if(parsedWeight >= parsedSalesRate) {
              // ...
          }
        } catch(Exception ex) {
               throw;
        }
    }
    
    
    
            public static string GetSalesrate(string expr)
            {
                return string.Join(null, Regex.Split(expr, ""));
        
            }
            public static string GetWeight(string expr)
            {
                return string.Join(null, Regex.Split(expr, ""));
        
            }
    

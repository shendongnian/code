        if(this.webBrowser3.InvokeRequired)
        {
        Invoke((MethodInvoker)(() => {
                    var table = webBrowser3.Document.GetElementById("emailTable");
                    var tr = table.GetElementsByTagName("tr");
                    if (tr.Count > 1)
                    {
                        var link = tr[1].GetElementsByTagName("td")[1].GetElementsByTagName("a")[0].GetAttribute("href");
                        webBrowser3.Navigate(link);
                    }                    
             });
         }

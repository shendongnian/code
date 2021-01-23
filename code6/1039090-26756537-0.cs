    string id { get ; set ;} 
        int lCount;
        List<string> ids = new List<string>{"A1201", "A1202", "A1203"};
        Datatable result = new Datatable();
        
        private void button1_Click(Object sender, EventArgs e)
        {
          
              lCount = i;
              webbrowser1.Navigate("http://www.sksit.com");
              webbrowser1.DocumentCompleted += new                     WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted)
           
        }
        
        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           if(e.URL.toString() == "http://www.sksit.com")
           {
              HtmlElement el = webbrowser1.Document.GetElementById("sid");
              el.SetAttribute("value", ids[lCount]);
        
              HtmlElement cl = webbrowser1.Document.GetElementById("Search");
              cl.InvokeMember("click");
           }
           elseif(e.URL.toString() == "http://www.sksit.com/studentprofiles")
           {
              HtmlElement el = webbrowser1.Document.GetElementById("studentinfotab");
              string info = el.InnerHtml;
              string[] tableinfo = info.Split(' ');
              DataRow trow = result.newDataRow();
              for(int j =0 ; j < tableinfo.Count() ; j++)
              {
                 trow[j] = tableinfo[j];
              }
              result.Rows.Add(trow);
           }
        }

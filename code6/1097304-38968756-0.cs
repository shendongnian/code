      void uxReportViewer_Hyperlink(object sender, HyperlinkEventArgs e)
      {
         Uri link = new Uri(e.Hyperlink);
         if (link.Authority == "someaction")
         {
            e.Cancel = true; //Cancel the event to avoid opening the browser
            char[] sep=new char[] {'='};
            var param=link.Query.Split(sep);
            string rowId=param[1];
            MessageBox.Show("You clicked on Id: "+rowId.ToString());
         }
      }

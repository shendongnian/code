        private void button1_Click(object sender, EventArgs e)
        {
            var wb = new WebBrowser
            {
                ScriptErrorsSuppressed = true
            };
            wb.Navigate("http://localhost:49689/Logon.aspx");
            while (wb.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();
            wb.Document.GetElementById("user").InnerText = "admin";
            wb.Document.GetElementById("password").InnerText = "cool";
            wb.Document.GetElementById("Submit1").InvokeMember("click");
            wb.DocumentCompleted += wb_DocumentCompleted;
            while (!completed)
                Application.DoEvents();
            var resultHeader = wb.Document.Url.OriginalString;
            var result = wb.Document.Body.InnerHtml;
            var cookie = wb.Document.Cookie;
            MessageBox.Show(cookie, "Cookie");
            MessageBox.Show(result, resultHeader);
        }
        private bool completed;
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            completed = true;
            ((WebBrowser)sender).DocumentCompleted -= wb_DocumentCompleted;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var elementsx = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement file in elementsx)
            {
                if (file.GetAttribute("type") == "file")
                {
                    listBox1.Items.Add(file.Style.ToString());
                    file.Focus();
                    file.InvokeMember("Click");
                    Task.Delay(500).ContinueWith(t => SendFileName(@"C:\Users\John\Desktop\test1\blue-book-motorcycle.jpg"), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
        private void SendFileName(string fileName)
        {
            SendKeys.Send(fileName + "{ENTER}");
        }

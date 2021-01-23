        private async void testButton_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(
                () =>
                {
                    stepTheWeb(() => wb.Navigate("www.yahoo.com"));
                    stepTheWeb(() => wb.Navigate("www.microsoft.com"));
                    stepTheWeb(() => wb.Navigate("asp.net"));
                    stepTheWeb(() => wb.Document.InvokeScript("eval", new[] { "$('p').css('background-color','yellow')" }));
                    bool testFlag = false;
                    stepTheWeb(() => testFlag = wb.DocumentText.Contains("Get Started"));
                    if (testFlag) {    /* TODO */ }
                    // ... 
                }
            );
        }
   
        private void stepTheWeb(Action task)
        {
            this.Invoke(new Action(task));
            WebBrowserReadyState rs = WebBrowserReadyState.Interactive;
            while (rs != WebBrowserReadyState.Complete)
            {
                this.Invoke(new Action(() => rs = wb.ReadyState));
                System.Threading.Thread.Sleep(300);
            }
       }

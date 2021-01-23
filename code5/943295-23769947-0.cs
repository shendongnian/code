    public static string GetGeneratedHTML(string url)
    {
        string result = null;
        ThreadStart pumpMessages = () =>
        {
            EventHandler idleHandler = null;
            idleHandler = (s, e) =>
            {
                Application.Idle -= idleHandler;
                WebBrowser wb = new WebBrowser();
                wb.DocumentCompleted += (s2, e2) =>
                {
                    result = wb.Document.Body.InnerHtml;
                    wb.Dispose();
                    Application.Exit();
                };
                wb.Navigate(url);
            };
            Application.Idle += idleHandler;
            Application.Run();
        };
        if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            pumpMessages();
        else
        {
            Thread t = new Thread(pumpMessages);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        return result;
    }

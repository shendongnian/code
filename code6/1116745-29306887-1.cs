    static void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (wb.Url.ToString().IndexOf("login.aspx") > -1)
        {
            wb.Document.GetElementById("txtnumber").SetAttribute("value", "000001");
            wb.Document.GetElementById("txtUserName").SetAttribute("value", "myusername");
            wb.Document.GetElementById("txtPassword").SetAttribute("value", "mypassword");
            wb.Document.GetElementById("btnLogin").InvokeMember("click");
        }
        else
        {
            //wb.Document.Body  you are logged in do whatever you want here.
            await Task.Delay(1000); //wait for 1 second just to let the WB catch up
            wb.Navigate("https://www.thewebsiteiwanttogo.com/product.aspx");
            Console.WriteLine(wb.DocumentText);
            Console.ReadLine();
            Application.Exit();
        }
    }

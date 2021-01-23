    const string url = "http://www.zip-codes.com/county/IL-COOK.asp";
    var doc = new HtmlWeb().Load(url);
    
    int end=0;
    HtmlNode basehref = new HtmlNode(HtmlNodeType.Element, doc, 0) { Name = "base" };
    basehref.Attributes.Add("href", url.Substring(0, url.LastIndexOf("/") + 1));
    doc.DocumentNode.SelectSingleNode("//head").ChildNodes.Insert(0, basehref);
    string html;
    using (var writer = new StringWriter()) {
        doc.Save(writer);
        html = writer.ToString();
    }
    
    var thread = new Thread(() => {
        var browser = new WebBrowser {
            Location = new Point(0, 0),
            Size = new Size(1920, 1080),
            ScriptErrorsSuppressed = true,
            AllowNavigation = true,
            DocumentText = html
        };
        browser.DocumentCompleted += (sender, e) => {
            Console.WriteLine(html.Length);
            Console.WriteLine(browser.DocumentText.Length);
            //Application.ExitThread();
            if (browser.ReadyState == WebBrowserReadyState.Complete)
            {
                    Application.ExitThread();   // Stops the thread
                    end = 1;
            }
        };
        Application.Run();
    });
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    //thread.Join();
    while (end == 0)
    {
        Thread.Sleep(10);
    }

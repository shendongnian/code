    CommonMethods cm = new CommonMethods();            
    WebClient webClient = new WebClient();
    XElement output = null;
    try
    {
        webClient = cm.ConnectCiscoUnityServerWebClient(IP, login, password);
        int rowsPerPage = 100;
        int pageNumber = 1;
        Console.WriteLine("Getting logins from " + IP);
        XElement result = new XElement("result"); // will hold results
        do
        {
            Console.WriteLine("Downloading " + pageNumber + " page");
            string uri = @"https://" + IP + ":" + port + 
               "/vmrest/users?bla&rowsPerPage=" + 
               rowsPerPage + "&pageNumber=" + pageNumber;
            Stream stream = webClient.OpenRead(uri);
            output = XElement.Load(stream);
            result.Add(output); // add current output to results
            pageNumber++;
        }
        while (output.HasElements);
        Console.WriteLine(result);
    }
    catch (Exception ex)
    {
        cm.LogErrors(ex.ToString(), MethodBase.GetCurrentMethod().Name.ToString());
    }

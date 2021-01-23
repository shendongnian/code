    Uri url = new Uri("https://svn.mysvn-apps.com/svn/PFE-DirDev-KPN/");   
         
    client.Authentication.DefaultCredentials = new NetworkCredential("user", "password");
            client.Authentication.SslServerTrustHandlers += delegate(object sender, SvnSslServerTrustEventArgs e)
            {
                e.AcceptedFailures = e.Failures;
                e.Save = true;
            };
    Collection<SvnListEventArgs> list;
    SvnUriTarget repo = new SvnUriTarget(url);
    try
    {
       client.GetList(repo, out list); // here generates the exception 
    }
    catch (Exception e)
    {
       // Do this or write e.ToString() to a log file or examine e in the Visual Studio debugger
       Console.WriteLine(e.ToString());
    }

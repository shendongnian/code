    using (var client = new SearchServiceClient())
    {
      client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
      client.Open();
      ViewBag.Results = client.SearchReports(searchTerm, page, 50);
      client.Close();
    }

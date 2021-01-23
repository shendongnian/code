    private class Permissions
    {
         public bool Admin { get; set; }
         public bool Push { get; set; }
         public bool Pull { get; set; }
    }
    
    private class GitHubRepo
    {
         public Permissions Permissions { get; set; }
         public string Name { get; set; }
    }
    
    public bool Authenticate(string userName, string password)
    {
    	try
    	{
    		var apiUrl = "https://api.github.com/";
    		var resource = "repos/myAccount/";
    		var repoName = "myRepo";
    
    		var client = new RestClient
    			{
    				BaseUrl = apiUrl,
    				Authenticator = new HttpBasicAuthenticator(userName, password)
    			};
    
    		var request = new RestRequest {Resource = string.Join("", resource, repoName)};
    
    		var response = client.Execute<List<GitHubRepo>>(request);
    		if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 209)
    		{
    			if (response.Data.Any(r => r.Name == repoName))
    			{
    				var repo = response.Data.Single(r => r.Name == repoName);
    
    				if (repo.Permissions.Admin || (repo.Permissions.Pull && repo.Permissions.Push))
    				{
    					return true;
    				}
    			}
    		}
    
    		return false;
    	}
    	catch
    	{
    		return false;
    	}
    }

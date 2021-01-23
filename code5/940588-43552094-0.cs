    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using System.Configuration;
    void Main()
    {
    	string TfsRepository = ConfigurationManager.AppSettings["TFS_Repository"];
    	string TfsUri = ConfigurationManager.AppSettings["TFS_URI"];
    	TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(TfsUri));
    	ttpc.EnsureAuthenticated();
    	var data = ttpc
    		.GetService<VersionControlServer>()
    		.GetPermissions(new string[] { TfsRepository }, RecursionType.Full)
    		.SelectMany(rr => rr.Entries.Select(itm => new { itm, rr.ServerItem }))
    		.Where(rr=>rr.itm.Allow.Length != 0)
    		.Select(rr => new { 
    			User = rr.itm.IdentityName,
    			Path = rr.ServerItem,
    			Permissions = String.Join(",", rr.itm.Allow)
    		})
    		.OrderBy(itm=>itm.User).ThenBy(itm=>itm.Path);
    }

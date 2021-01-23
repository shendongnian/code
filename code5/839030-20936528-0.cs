    this._contentService.Endpoint.Behaviors.Add(
    	new BasicAuthenticationBehavior(
    		username: this.Settings.HttpUser,
    		password: this.Settings.HttpPass));
    var binding = (BasicHttpBinding)this._contentService.Endpoint.Binding;
    binding.Security.Mode = BasicHttpSecurityMode.Transport; // SSL only            
    binding.Security.Transport.ClientCredentialType = 
       HttpClientCredentialType.None; // Do not provide

        // Check if we have scopes 
        var AllScopes = principal.Claims.Where(p => p.Type == "scopes");
        // Check if we have desired scope 
        foreach (var singlescope in AllScopes)
        {
            Dictionary<string, List<string>> userscopes = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(singlescope.Value);
            if (userscopes.Single(kvp => kvp.Key == ScopeName).Value.Contains(ScopeAccess))
            {
                //User is Authorized, complete execution
                return Task.FromResult<object>(null);
            }
        }

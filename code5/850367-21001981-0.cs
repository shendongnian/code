    public bool CheckIfBrowserExists(string name, string version)
        {
            var result =
                this.ClientRepositories
                    .Proxies
                    .Execute<IEnumerable<bool>>("CheckIfBrowserExists");
    
            return result.Single();
        }

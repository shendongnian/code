    private static Dictionary<string, Assembly> _cachedAssemblies =
        new Dictionary<string, Assembly>();
    
    public static Assembly LoadRemoteAssembly(string url)
    {
        lock (_cachedAssemblies)
        {
            if (_cachedAssemblies.ContainsKey(url))
                return _cachedAssemblies[url];
    
            var data = new WebClient.DownloadData(url); // For example...
            var assembly = Assembly.Load(data);
    
            _cachedAssemblies.Add(url, assembly);
    
            return assembly;
        }
    }

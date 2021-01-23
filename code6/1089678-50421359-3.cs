    public void Configure(
        IApplicationBuilder app,
        IHostingEnvironment env,
        IApplicationLifetime applicationLifetime, // Add
        IRouteAnalyzer routeAnalyzer // Add
    )
    {
        ...
    
        // Add this block
        applicationLifetime.ApplicationStarted.Register(() =>
        {
            var infos = routeAnalyzer.GetAllRouteInformations();
            Debug.WriteLine("======== ALL ROUTE INFORMATION ========");
            foreach (var info in infos)
            {
                Debug.WriteLine(info.ToString());
            }
            Debug.WriteLine("");
            Debug.WriteLine("");
        });
    }

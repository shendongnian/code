            var js = new JavaScriptSerializer();
            var array = js.Deserialize<List<object>>(JsonData); // Deserialize outer array
            var compList = new CompList
            {
                AppTypes = array
                    .OfType<IEnumerable<object>>()          // Enumerate through nested arrays
                    .SelectMany(o => o)                     // Enumerate through elements in nested arrays
                    .OfType<IDictionary<string, object>>()  // Pick out those which are JSON objects (deserialized as dictionaries)
                    .Where(d => d.ContainsKey("AppType"))   // Filter those that are AppTypes 
                    .Select(d => js.ConvertToType<AppTypes>(d)) // Deserialize to the AppTypes class
                    .ToList(),
                CompType = array
                    .OfType<IEnumerable<object>>()
                    .SelectMany(o => o)
                    .OfType<IDictionary<string, object>>()
                    .Where(d => d.ContainsKey("CompType"))
                    .Select(d => js.ConvertToType<CompTypes>(d))
                    .ToList(),
            };

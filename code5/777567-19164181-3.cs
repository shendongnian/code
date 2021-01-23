     private static Dictionary<string, List<string>> GetAllUpdates(IUpdate iUpdate)
            {
                var bundleDict = new Dictionary<string, List<string>>();
                foreach (IUpdate bundle in iUpdate.BundledUpdates)
                {
                    foreach (IUpdateDownloadContent udc in bundle.DownloadContents)
                    {
                        var downloadContents = new List<string>();
                        if (String.IsNullOrEmpty(udc.DownloadUrl))
                            continue;
    
                        var url = udc.DownloadUrl;
                        downloadContents.Add(url);
                        if (!bundleDict.ContainsKey(bundle.Title))   
                            bundleDict.Add(bundle.Title, downloadContents);
                    }
    
                    if (bundle.BundledUpdates.Count > 0)
                    {
                        var valuesReturned = GetAllUpdates(bundle);
                        foreach (var data in valuesReturned)
                        {
                          if(!bundleDict.ContainsKey(data.Key))     
                             bundleDict.Add(data.Key, data.Value);
                        }
                            
                    }
                }
    
                return bundleDict;
            }

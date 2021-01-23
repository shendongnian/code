    /// Do Stuff in Async method
    using (HttpClient hc = new HttpClient())
    {
        hc.BaseAddress = CatalogUri;
        hc.DefaultRequestHeaders.Accept.Add(HttpJsonHeader);
        if (Session["StandardSearchOptions"] == null || rebindStandardOptions)
        {
            // request for standard options
            HttpResponseMessage stdResponse = hc.PostAsJsonAsync(CatalogSearchOptionPath,
                                                     searchmeta).Result;
            IEnumerable<Task<KeyValuePair<string, List<string>>>> tasks = 
                                   from key in keynames 
                                   select GetCustomOptionList(key, hc, searchmeta);
            customOptions = new ConcurrentDictionary<string, List<string>>(await
                                                        Task.WhenAll(tasks));
            if (stdResponse.IsSuccessStatusCode)
            {
                string g = stdResponse.Content.ReadAsStringAsync().Result;
                stdOptions = Newtonsoft.Json
                              .JsonConvert.DeserializeObject<List<SearchOption>>(g);
            }
            Session["StandardSearchOptions"] = stdOptions;
        }
        else // only rebinding the custom options
        {
            IEnumerable<Task<KeyValuePair<string, List<string>>>> tasks = 
                                                      from key in keynames 
                                                      select GetCustomOptionList(key, hc,
                                                                             searchmeta);
            customOptions = new ConcurrentDictionary<string, List<string>>(await 
                                                                  Task.WhenAll(tasks));
        }
    }
    /// Do other stuff in Async Method

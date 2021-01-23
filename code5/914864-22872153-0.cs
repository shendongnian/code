    var tasks = uris.Select(async uri =>
                {
                    using (var client = new HttpClient())
                    {
                        return await client.GetStringAsync(uri)
                    }
                })
                .ToList();

       client.ExecuteAsync(request, response =>
                {
                    var rootObject = JsonConvert.DeserializeObject<RootObject>(response.Content);
                    table.InvokeOnMainThread(() =>
                        {
                            table.Source = new TableSource(rootObject.data);
                            table.ReloadData();
                        });
                }
            );

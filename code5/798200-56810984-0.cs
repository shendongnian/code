    public class tbDevices
    {
        public tbDevices()
        {
            this.Items = new ObservableCollection<tbDevice>();
        }
        public ObservableCollection<tbDevice> Items { get; }
        public async Task<IRestResponse> GET(Control caller, int limit = 0, int offset = 0, int timeout = 10000)
        {
            return await Task.Run(() =>
            {
                try
                {
                    IRestResponse response = null;
                    var request = new RestRequest(Globals.restDevices, Method.GET, DataFormat.Json);
                    if (limit > 0)
                    {
                        request.AddParameter("limit", limit);
                    }
                    if (offset > 0)
                    {
                        request.AddParameter("offset", offset);
                    }
                    request.Timeout = timeout;
                    try
                    {
                        var client = new RestClient(Globals.apiProtocol + Globals.apiServer + ":" + Globals.apiPort);
                        client.Authenticator = new HttpBasicAuthenticator(Globals.User.email.Trim(), Globals.User.password.Trim());
                        response = client.Execute(request);
                    }
                    catch (Exception err)
                    {
                        throw new System.InvalidOperationException(err.Message, response.ErrorException);
                    }
                    if (response.ResponseStatus != ResponseStatus.Completed)
                    {
                        throw new System.InvalidOperationException("O servidor informou erro HTTP " + (int)response.StatusCode + ": " + response.ErrorMessage, response.ErrorException);
                    }
                    // Will do a one-by-one data refresh to preserve sfDataGrid UI from flashing
                    List<tbDevice> result_objects_list = null;
                    try
                    {
                        result_objects_list = JsonConvert.DeserializeObject<List<tbDevice>>(response.Content);
                    }
                    catch (Exception err)
                    {
                        throw new System.InvalidOperationException("Não foi possível decodificar a resposta do servidor: " + err.Message);
                    }
                    // Convert to Dictionary for faster DELETE loop
                    Dictionary<string, tbDevice> result_objects_dic = result_objects_list.ToDictionary(x => x.id, x => x);
                    // Async update this collection as this may be a UI cross-thread call affecting Controls that use this as datasource
                    caller?.BeginInvoke((MethodInvoker)delegate ()
                    {
                        // DELETE devices NOT in current_devices 
                        for (int i = this.Items.Count - 1; i > -1; i--)
                        {
                            result_objects_dic.TryGetValue(this.Items[i].id, out tbDevice found);
                            if (found == null)
                            {
                                this.Items.RemoveAt(i);
                            }
                        }
                        // UPDATE/INSERT local devices
                        foreach (var obj in result_objects_dic)
                        {
                            tbDevice found = this.Items.FirstOrDefault(f => f.id == obj.Key);
                            if (found == null)
                            {
                                this.Items.Add(obj.Value);
                            }
                            else
                            {
                                found.Merge(obj.Value);
                            }
                        }
                    });
                    return response;
                }
                catch (Exception)
                {
                    throw; // This preserves the stack trace
                }
            });
        }
    }

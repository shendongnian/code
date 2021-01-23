     public static Dictionary<string, Servers> loadServers() {
                    WebClient client = new WebClient();
                    string getString = client.DownloadString("http://flippr.pw/en/web_service/servers.json");
                    client.Dispose();
                    Dictionary<string, Servers> listOfServers =                        JsonConvert.DeserializeObject<Dictionary<string, Servers>>(getString);
                    return listOfServers;
                }

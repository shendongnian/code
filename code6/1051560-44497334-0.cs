        public static async void DynamicUpdate(string hostname, string myip, string username, string password) {
            try {
                string noipuri = "http://dynupdate.no-ip.com/nic/update?hostname=" + hostname + "&myip=" + myip;
                using (var client = new HttpClient(new HttpClientHandler { Credentials = new NetworkCredential(username, password) }))
                using (var response = await client.GetAsync(noipuri))
                using (var content = response.Content) {
                    await content.ReadAsStringAsync();
                }
            }
            catch {
            }
        }

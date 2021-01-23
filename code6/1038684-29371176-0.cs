    public async Task<string> GetMethod(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url); // The Get Process to get result from WCF service
            string result = await response.Content.ReadAsStringAsync(); // Get Json string result
            return result;
            }
        }

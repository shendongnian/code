        public async Task<WeatherStatus> GetWeatherStatus (string zip)
        {
            var client = new HttpClient();
            var msg = await client.GetAsync(string.Format(WeatherApiUrlBase, WeatherApiKey, zip)).ConfigureAwait(false);
            if (msg.IsSuccessStatusCode)
            {
                using (var stream = await msg.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var str = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                        var obj = JsonConvert.DeserializeObject<WeatherStatus>(str);
                        return obj;
                    }
                }
            }
            return null;
        }

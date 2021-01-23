        using (var httpFilter = new HttpBaseProtocolFilter())
        {
            using (var httpClient = new HttpClient(httpFilter))
            {
                Uri requestUri = new Uri("");
                string json = await JsonConvert.SerializeObjectAsync(CredentialsModel);
                var response = await httpClient.PostAsync(requestUri, new HttpStringContent(json, UnicodeEncoding.Utf8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Ok)
                {
                    var responseAsString = await response.Content.ReadAsStringAsync();
                    var deserializedResponse = await JsonConvert.DeserializeObjectAsync<IEnumerable<Appointment>>(responseAsString);
                }
            }
        }

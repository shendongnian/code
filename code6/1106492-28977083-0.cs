        public async Task<YourResponseDTO> GetResponseDTO()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("localhost/your-web-api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("your-first-endpoint");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var mediaType = response.Content.Headers.ContentType.MediaType;
                if (mediaType != "application/json")
                {
                    return null;
                }
                var responseObject = await response.Content.ReadAsAsync<YourResponseDTO>();
                return responseObject;
            }
        }

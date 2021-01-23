            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(token), "token");
            var imageForm = new ByteArrayContent(imagen, 0, imagen.Count());
            imagenForm.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            form.Add(imagenForm, "image", "nameholder.jpg");
            
            HttpResponseMessage response = await httpClient.PostAsync("your_url_here", form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            string result = response.Content.ReadAsStringAsync().Result;

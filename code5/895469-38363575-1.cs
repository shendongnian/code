        public async Task DoStuff()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = "http://localhost/";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                RegisterUserRequest content = new RegisterUserRequest { ConfirmPassword = "foo", Password = "foo", Email = "foo@bar" };
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/Register", content).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    BadRequestResponse message = await response.Content.ReadAsAsync<BadRequestResponse>().ConfigureAwait(false);
                    // do something with "message.ModelState.Values"
                }
            }
        }

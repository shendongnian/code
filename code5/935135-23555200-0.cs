    using System.Net.Http;
    using System.Net.Http.Headers;
            var userData = new User()
            {
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                companyName = txtCompanyName.Text,
                email = txtEmail.Text,
                phone = txtPhone.Text
            };
                client.BaseAddress = new Uri("http://yourBaseUrlHere");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync("requestUrlHere", user);
                if (response.IsSuccessStatusCode)
                {
                    //Success code
                }

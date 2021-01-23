            // Create the message
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(singletonInstance.APIServer + "MkhAdapter/rest/mkh/Login"));
            // Add the message body
            message.Content = new StringContent(
                "{'UserCategory': 'user','Email': User_EnteredUsername, 'Password':User_EnteredPassword}",
                System.Text.UTF8Encoding.UTF8, "application/json");
            // Send
            var client = new HttpClient();
            var result = await client.SendAsync(message, cancellationToken);
            result.EnsureSuccessStatusCode();
            // Get ids from result
            return (await result.Content.ReadAsStringAsync());

            WebClient client = new WebClient();
            String username = "ID";
            String password = "PW";
            string url = "http://x.com/api/" + username;
            client.Credentials =  new System.Net.NetworkCredential(username,password);
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
            
            client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
            
            var result = client.DownloadString(url);
            textBox1.Text = result;

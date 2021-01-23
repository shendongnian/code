    var url = @"..."; 
                var mybar= new System.Collections.Specialized.NameValueCollection();
                mybar.Add("username", "username");
                mybar.Add("password", "password");
                var client = new System.Net.WebClient();
                var data = client.UploadValues(url, mybar);
                var res = System.Text.Encoding.ASCII.GetString(data);
                Console.WriteLine(res);
                Console.ReadLine();

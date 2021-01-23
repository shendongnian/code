     var client = new GwebSearchClient("http://www.google.com");
            var results = client.Search("google api for .NET", 100);
            foreach (var webResult in results)
            {
                //Console.WriteLine("{0}, {1}, {2}", webResult.Title, webResult.Url, webResult.Content);
                listBox1.Items.Add(webResult.ToString ());
            }

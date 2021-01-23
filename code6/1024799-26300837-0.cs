            var client = new HttpClient();
 
            var stream3 = new FileStream("saved.jpg", FileMode.Open);
            var stream2 = new FileStream("saved2.jpg", FileMode.Open);
 
            var dic = new Dictionary<string, string>();
            dic.Add("Test1", "This was the first test.");
 
            var addy = "http://posttestserver.com/post.php";
 
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(stream2), "s1", "Saved1.jpg");
                content.Add(new StreamContent(stream3), "s2", "Saved2.jpg");
                var response = await client.PostAsync(addy, content);
                response.EnsureSuccessStatusCode();
 
                string finalresults = await response.Content.ReadAsStringAsync();
            }

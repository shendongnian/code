     using (HttpClient client = new HttpClient())
     {
         string s = client.GetStringAsync(url).Result.ToLower();
         lock(result)
         {
             result.Append(s);
         }
         
         Debug.WriteLine(count);
         count++;
     }

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
        public async Task<string> RunHttpPost(string city, string Id)
        {
            var _url = String.Format("http://www.example.com/gps/?city={0}&Id={1}",city,Id);           
              
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
                var values = new Dictionary<string, string>{
                    
                { "city", city },
                { "Id", Id }
                };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(_url, content);
               return await response.Content.ReadAsStringAsync();
            }

            WebHeaderCollection wHeader = new WebHeaderCollection();
            wHeader.Clear();
            //wHeader.Add("username:test");
            //wHeader.Add("password:4afe2a8a38fbd29c32e8fcd26dc51f6d9b5ab99b");
            //wHeader.Add("u","test:4afe2a8a38fbd29c32e8fcd26dc51f6d9b5ab99b");
            string Username = "test";
            string ApiToken = "4afe2a8a38fbd29c32e8fcd26dc51f6d9b5ab99b";
            string sUrl = "https://store-bwvr466.mybigcommerce.com/api/v2/brands.json";  //txtstoreurl.Text.ToString() + "/api/v2/products.json";
            HttpWebRequest wRequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(sUrl);
            wRequest.Credentials = new NetworkCredential(Username, ApiToken);
            wRequest.ContentType = "application/json"; //' I don't know what your content type is
            //wRequest.Headers = wHeader;
            wRequest.Method = "GET";
            HttpWebResponse wResponse = (HttpWebResponse)wRequest.GetResponse();
            string sResponse = "";
            using (StreamReader srRead = new StreamReader(wResponse.GetResponseStream()))
            {
                sResponse = srRead.ReadToEnd();
                MessageBox.Show(sResponse);
            }

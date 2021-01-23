                 string url = "http://Example.com/admin"
                 using (WebClient client = new WebClient()) 
                 {                    
                     var data = new NameValueCollection();
                     data.Add("username","asdsdsad");
                     data.Add("extension", 123);                    
                    
                     var Bytecode = client.UploadValues(url, data);
                     string htmlCode = Encoding.UTF8.GetString(Bytecode, 0, Bytecode.Length);
                     // Or you can get the file content without saving it:
                 }

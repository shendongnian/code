                string samlString = "blah blah blah";
                byte[] bytes = Encoding.UTF8.GetBytes(samlString);
                string base64SamlString = Convert.ToBase64String(bytes);
                myHttpClient.DefaultRequestHeaders.Add("X-My-Custom-Header", base64SamlString);
 

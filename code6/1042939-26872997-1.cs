                // Fix missing outer parenthesis
                var fixedLine = "{" + line + "}";
                // Parse into a JObject
                var mapping = JObject.Parse(fixedLine);
                
                // Extract the "response" and deserialize it.
                Response r = mapping["response"].ToObject<Response>();
                Debug.WriteLine(r.count);
                foreach (var item in r.items)
                {
                    Debug.WriteLine(item);
                }

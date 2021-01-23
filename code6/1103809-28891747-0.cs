                  string text = System.IO.File.ReadAllText("json.txt");
                    
                    //this line is WRONG!!
                    string serializeObject = JsonConvert.SerializeObject(text);
    
                    //this fails because serializeObject is a double serialized string
                   //which you try to deserialize to RootOject                
                     var deserializeObject = JsonConvert.DeserializeObject<RootObject>(serializeObject);
            
                        return JsonConvert.SerializeObject(text);
                    

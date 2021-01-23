    using (FileStream fs = File.Open(@"c:\temp\a.json", FileMode.Create))
         using (StreamWriter sw = new StreamWriter(fs))
              using (JsonWriter jw = new JsonTextWriter(sw))
                   {
                       jw.Formatting = Formatting.Indented;
    
                       JsonSerializer serializer = new JsonSerializer();
                       sw.Write("[");
                       serializer.Serialize(jw, obj1);
                       sw.Write(",");
                       serializer.Serialize(jw, obj2);
                       sw.Write(",");
                       serializer.Serialize(jw, obj3); 
                       sw.Write("]");
                    }

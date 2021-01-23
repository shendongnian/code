    var memory = new MemoryStream();
                 var serial = new XmlSerializer(objectToSerialize.GetType());
                 serial.Serialize(memory, objectToSerialize);  
                var utf8 = new UTF8Encoding();
                return utf8.GetString(memory.GetBuffer(), 0, (int)memory.Length);

     using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(xml)))
           {
            DataContractSerializer serializer = new DataContractSerializer(person.GetType());
           return (person)serializer.ReadObject(ms);
           
           }

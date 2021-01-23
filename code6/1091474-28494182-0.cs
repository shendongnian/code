            var serializer = new XmlSerializer(typeof(MappedClass));
            serializer.UnknownAttribute += 
                (s, e) =>
                {
                    (e.ObjectBeingDeserialized as MappedClass).Codes.Add(new Code { Name = e.Attr.Name, Value = e.Attr.Value });                                        
                };      

            using (var xmlReader = XmlReader.Create(stream))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Location[]));
                var locations = (Location[])serializer.ReadObject(xmlReader);
                Debug.WriteLine(DataContractSerializerHelper.GetXml(locations, serializer)); // Debug check on re-serialization, remove when not needed.
            }

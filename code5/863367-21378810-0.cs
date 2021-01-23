            var serializer = new XmlSerializer(typeof(ObservableCollection<LoginData>));
            var collection = new ObservableCollection<LoginData>
            {
                new LoginData { Username = "admin", Password = "123" },
                new LoginData { Username = "johndoe", Password = "456" }
            };
            var sb = new StringBuilder();
            // serialize
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, collection);
            }
            // deserialize
            using (var reader = new StringReader(sb.ToString()))
            {
                var collectionClone = serializer.Deserialize(reader);
            }

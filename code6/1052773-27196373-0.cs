        private GameOptions Deserialize()
        {
            var serializer = new XmlSerializer(typeof(GameOptions));
            using (var reader = new StreamReader(@"savedmap.xml"))
            {
                return (GameOptions)serializer.Deserialize(reader);
            }
        }

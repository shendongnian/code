        public static T CopyPatch<T>(T obj, string patch)
        {
            var serializer = new JsonSerializer();
            var json = JsonConvert.SerializeObject(obj);
            var copy = JsonConvert.DeserializeObject<T>(json);
            using (var reader = new StringReader(patch))
            {
                serializer.Populate(reader, copy);
            }
            return copy;
        }

        public static string GetObjectHash<T>(this T foo)
        {
            byte[] serializedData = null;
            var hasher = SHA256.Create();
            var serializer = new DataContractSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, foo);
                serializedData = stream.ToArray();
            }
            serializedData = hasher.ComputeHash(serializedData);
            return String.Concat(serializedData.Select(d => d.ToString("x2")));
        }

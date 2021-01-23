     public static bool Deserialize<T>(this String str, out T item)
        {
            item = default(T);
            try
            {
                using (var reader = XmlReader.Create(new StringReader(str)))
                {
                    item = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

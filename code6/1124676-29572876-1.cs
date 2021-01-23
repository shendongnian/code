        internal static class Source
        {
            internal static bool Save<T>(T data, string saveFilePath)
            {
                var ser = new XmlSerializer(typeof(T));
                using (var sw = new StreamWriter(saveFilePath, false, Encoding.UTF8))
                {
                    using (var usw = new Utf8StringWriter())
                    {
                        ser.Serialize(usw, data);
                        sw.Write(usw.ToString());
                    }
                }
                return true;
            }
        }

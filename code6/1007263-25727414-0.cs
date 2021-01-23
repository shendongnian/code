    static class XmlUtils {
        public static T Load<T>(string filename, Func<T> onMissing = null)
            where T : class, new()
        {
            using (var fs = File.OpenRead(filename)) {
                var serializer = new XmlSerializer(typeof(T));
                try {
                    return (T)serializer.Deserialize(fs);
                } catch (InvalidOperationException) { // catch "file not found"
                    return onMissing == null ? new T() : onMissing();
                }
            }
        }
    }

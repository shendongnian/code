    class ImageFile
    {
        public string Name { get; set; }
        public string Base64Image { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var files = new[] { "test.bmp", "test2.bmp" };
            // generate all the objects and then serialize.
            var imageFiles = files.Select(GenerateImageFile);
            var serialized = JsonConvert.SerializeObject(imageFiles.ToArray(), Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            Console.WriteLine(serialized);
            // generate objects one at a time.
            // use JsonSerialzer/JsonTextWriter to "stream" the objects
            var s = JsonSerializer.Create(new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var strWriter = new StringWriter();
            using (var writer = new JsonTextWriter(strWriter) { Formatting = Formatting.Indented })
            {
                writer.WriteStartArray();
                foreach(var file in files)
                {
                    var imageFile = GenerateImageFile(file);
                    s.Serialize(writer, imageFile);
                }
                writer.WriteEndArray();
            }
            Console.WriteLine(strWriter.GetStringBuilder());
        }
        private static ImageFile GenerateImageFile(string fileName)
        {
            return new ImageFile() { Name = fileName, Base64Image = fileName + fileName };
        }
    }

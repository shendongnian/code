    public class ViewModel
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string ImagePath { get; set; }
        public string DestinationName { get; set; }
        public void Start()
        {
            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(q => q.Contains("Template.html")).FirstOrDefault();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string html = reader.ReadToEnd().Replace("$$TEXT1$$", Text1).Replace("$$TEXT2", Text2).Replace("$$IMAGELOCATION$$", ImagePath);
                    File.WriteAllText(DestinationName, html);
                }
            }
        }
    }

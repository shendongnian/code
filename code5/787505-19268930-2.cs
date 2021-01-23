    class PictureLoader {
        private readonly string[] _images;
        public PictureLoader(string path) {
            _images = Directory.GetFiles(path, "*.jpg");
        }
        public IEnumerable<Tuple<string, string, string>> GetRowData() {
            foreach (var imagePath in _images) {
                var extension = Path.GetExtension(imagePath);
                var fileName = Path.GetFileName(imagePath);
                var regex = Regex.Match(fileName, @"([A-Za-z]+)-(\d{4}-\d{2}-\d{2})(.[A-Za-z]+)");
                var name = regex.Groups[1].Value;
                var date = DateTime.ParseExact(regex.Groups[2].Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                yield return
                    new Tuple<string, string, string>(name + extension, date.ToString(),
                        (new FileInfo(imagePath).Length / 1024).ToString() + " KB");
            }
        }
    }

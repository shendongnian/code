    public class FileParserHttpPostedFileBase : FileParser<HttpPostedFileBase> {
        public string Parse(HttpPostedFileBase source) {
            return file.FileName;
        }
    }
    public class FileParserUri : FileParser<Uri> {
        public string Parse(Uri source) {
            return Uri.ToString();
        }
    }

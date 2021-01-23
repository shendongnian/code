        public FileResult Downloadfile(string directoryname, string filename)
        {
            string _fileName = filename + ".pdf";
            string _directory = directoryname + "/";
            string root = "~/Content/";
            string path = Server.MapPath(root + _directory + _fileName);
            return new FileContentResult(System.IO.File.ReadAllBytes(path), _fileName);
        }

        public ContentResult FileContent()
        {
            var data = string.Empty;
            var path = @"c:\temp\output.txt";
            if (System.IO.File.Exists(path))
            {
                data = System.IO.File.ReadAllText(path);
            }
            return Content(data);
        }

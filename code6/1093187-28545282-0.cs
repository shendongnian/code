        public ActionResult GetFile()
        {
            var fileName = Path.GetTempFileName();
            System.IO.File.WriteAllText(fileName, "Hola, Chile!");
            var bytes = System.IO.File.ReadAllBytes(fileName);
            System.IO.File.Delete(fileName);
            return File(bytes, "text/plain", "file.txt");
        }

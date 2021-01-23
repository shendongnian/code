        public void DeleteFilesExcept(string directory,List<string> excludes)
        {
            var files = System.IO.Directory.GetFiles(directory).Where(x=>!excludes.Contains(System.IO.Path.GetFileName(x)));
            foreach (var file in files)
            {
                System.IO.File.Delete(file);
            }
        }

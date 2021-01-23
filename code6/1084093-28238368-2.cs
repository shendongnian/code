            string pattern = "*.cs";
            ViewBag.Message = "Your contact page.";
            DirectoryInfo dirInfo = new DirectoryInfo(@"f:\");
            List<string> filenames = new List<string>();
            foreach (FileInfo f in dirInfo.GetFiles(pattern))
            {
                filenames.Add(f.Name);  //or f.FullName to include path
            }
            pattern = "*.cpp";
            foreach (string f in dirInfo.GetFiles(pattern))
            {
                filenames.Add(f);
            }
            ViewBag.data = filenames;
            return View(filenames);

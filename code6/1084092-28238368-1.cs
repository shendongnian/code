            public ActionResult Contact()
        {
            string pattern = "*.cs|*.cpp";
            ViewBag.Message = "Your contact page.";
            DirectoryInfo dirInfo = new DirectoryInfo(@"f:\");
            List<string> filenames = new List<string>();
            string[] temp = pattern.Split('|');
            for (int i = 0; i < temp.Length; i++)
            {
                filenames.AddRange(GetFiles(temp[i]));
            }
            ViewBag.data = filenames;
            return View(filenames);
        }
        public List<string> GetFiles(string pattern) {
            DirectoryInfo dirInfo = new DirectoryInfo(@"f:\");
            List<string> filenames = new List<string>();
            foreach (string f in dirInfo.GetFiles(pattern))
            {
                filenames.Add(f);
            }
            return filenames;
        }

    public ActionResult Index()
    {
        //creating a DirectoryInfo object
        DirectoryInfo mydir = new DirectoryInfo(@"\\edcapptest\E$\cdn\js\jquery");
    
        // getting the files in the directory
        var myList = mydir.GetFiles()  // Your objects in the list you start with
            // Filter for the jquery files... you may not need this line
            .Where(file => file.Name.StartsWith("jquery-"))
            // Select the filename and version number so we can sort  
            .Select(file => new { Name= file.Name, Version = GetVersion(file.Name)}) 
            // OrderBy the version number
            .OrderBy(f => f.Version)
            // We have to select just the filename since that's all you want
            .Select(f => f.Name)
            // Convert your output into a List 
            .ToList();                 
    
        return View(myList);
    }
        // GetVersion code and regex to remove characters...
        private static Regex digitsOnly = new Regex(@"[^\d]");
        public static Version GetVersion(string filename)
        {
            var versionNumbers = new List<int>();
            var splits = filename.Split('.');
            foreach (var split in splits)
            {
                var digits = digitsOnly.Replace(filename, "");
                if (!string.IsNullOrEmpty(digits))
                    versionNumbers.Add(int.Parse(digits));
            }
            // Create a version which can have various major / minor versions and 
            //   handles sorting for you.
            return new Version(versionNumbers[0], versionNumbers[1], 
                           versionNumbers[2]);
        }

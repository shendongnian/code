     public IEnumerable<string> DirectoryScan(string directory)
        {
            List<string> extensions = new List<string>
            {
            "docx","xlsx","pptx","docm","xlsm","pptm","dotx","xltx","xlw","potx","ppsx","ppsm","doc","xls","ppt","doct","xlt","xlm","pot","pps"
            };
            IEnumerable<string> myFiles =
                Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                    .Where(s => extensions.Any(s.EndsWith))
                    .ToList();
            return myFiles;
        }`

        static void Main(string[] args)
        {
            var myDrives = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Fixed);
            foreach (var drive in myDrives)
            {
                var outp = GetAllSubFolders(drive.Name,@"\Driver");
                foreach (var folder in outp)
                {
                    Console.WriteLine(folder);
                }
            }
        }
        static IEnumerable<string> GetAllSubFolders(string folder, string pathSubString)
        {
            try
            {
                var dirInfo = new DirectoryInfo(folder);
                return dirInfo.GetDirectories().SelectMany(x => GetAllSubFolders(x.FullName, pathSubString))
                    .Concat(dirInfo.GetDirectories().Select(x => x.FullName).Where(x => x.Contains(pathSubString)));
            }
            catch
            {
                return new List<string>();
            }
            
        }

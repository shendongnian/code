    public class HdCleaner
    {
        public static void DeleteOldestFiles(long minimumAvailableSpace, string path)
        {
            var driveLetter = Path.GetPathRoot(path);
            var drive1 = DriveInfo.GetDrives().Where(d => d.IsReady).Single(d => d.Name == driveLetter);
            while (drive1.TotalFreeSpace <= minimumAvailableSpace)
            {
                var info = new DirectoryInfo(path);
                var file = info.GetFiles().OrderBy(p => p.LastWriteTime).First();
                file.Delete();
            }
        }
    }

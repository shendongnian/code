    public static class FileNameHelper
    {
        public static string GetFileNameFromPath(string path, string extWithoutdot = "cs")
        {
            var startIndex = path.LastIndexOf('/') + 1;
            var stringg = path.Substring(startIndex);
            var remIndex = stringg.LastIndexOf("." + extWithoutdot) + extWithoutdot.Length+1;
            return stringg.Remove(remIndex);
        }
    }

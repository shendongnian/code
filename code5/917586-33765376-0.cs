    public static string ShareToLocalPath(string sharePath)
    {
        try
        {
            var regex = new Regex(@"\\\\([^\\]*)\\([^\\]*)(\\.*)?");
            var match = regex.Match(sharePath);
            if (!match.Success) return "";
            var shareHost = match.Groups[1].Value;
            var shareName = match.Groups[2].Value;
            var shareDirs = match.Groups[3].Value;
            var scope = new ManagementScope(@"\\" + shareHost + @"\root\cimv2");
            var query = new SelectQuery("SELECT * FROM Win32_Share WHERE name = '" + shareName + "'");
            using (var searcher = new ManagementObjectSearcher(scope, query))
            {
                var result = searcher.Get();
                foreach (var item in result) return item["path"].ToString() + shareDirs;
            }
            return "";
        }
        catch (Exception)
        {
            return "";
        }
    }

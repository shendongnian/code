    public static string ImageVersion(string name) {
      FileInfo info = new FileInfo(HttpContect.Current.MapPath(name));
      int time = (int)((info.LastWriteTimeUtc - new DateTime(2000,1,1)).TotalMinutes);
      return "?v=" + time.ToString();
    }

    using System;
    using System.Linq;
    using System.IO;
     
    namespace Firefox
    {
    class Reader
    {
    public static string ReadFirefoxProfile()
    {
    string apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
     
    string mozilla = System.IO.Path.Combine(apppath, "Mozilla");
     
    bool exist = System.IO.Directory.Exists(mozilla);
     
    if (exist)
    {
     
    string firefox = System.IO.Path.Combine(mozilla, "firefox");
     
    if (System.IO.Directory.Exists(firefox))
    {
    string prof_file = System.IO.Path.Combine(firefox, "profiles.ini");
     
    bool file_exist = System.IO.File.Exists(prof_file);
     
    if (file_exist)
    {
    StreamReader rdr = new StreamReader(prof_file);
     
    string resp = rdr.ReadToEnd();
     
    string[] lines = resp.Split(new string[] { "\r\n" }, StringSplitOptions.None);
     
    string location = lines.First(x => x.Contains("Path=")).Split(new string[] { "=" }, StringSplitOptions.None)[1];
     
    string prof_dir = System.IO.Path.Combine(firefox, location);
     
    return prof_dir;
    }
    }
    }
    return "";
    }
    }
    }

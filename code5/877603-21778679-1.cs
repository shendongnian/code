    using System.IO;
    using System.Reflection;
    private string pathStartUp = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
    var exe = Assembly.GetExecutingAssembly().Location;
    var destiny = Path.Combine(pathStartUp, Path.GetFileName(exe));
    var data = File.ReadAllBytes(exe);
    File.WriteAllBytes(destiny, data);

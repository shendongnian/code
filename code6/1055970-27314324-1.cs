    using System.IO;
    using System.Reflection;
    string appDirectory =  Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
 
    string templatePath = Path.Combine(appDirectory, "EmailTemplateMini.html");

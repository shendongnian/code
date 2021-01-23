    using System.IO;
    
    namespace WebApplication1
    {
        public class Global : System.Web.HttpApplication
        {
            FileSystemWatcher watcher;
    
            void Application_Start(object sender, EventArgs e)
            {
                // Code that runs on application startup
                watcher = new FileSystemWatcher(this.Context.Server.MapPath("/"));
                watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            }
    
            void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                //set a value in js file
                FileInfo jsFilesChanged = new FileInfo(Path.Combine(this.Context.Server.MapPath("/"), "scripts", "files_changed.js"));
                using (StreamWriter jsWriter = (!jsFilesChanged.Exists) ? new StreamWriter(jsFilesChanged.Create()) : new StreamWriter(jsFilesChanged.FullName, false))
                {
                    jsWriter.WriteLine("var changed_file = \"" + e.Name + "\";");
                }
            }
    
            //.......
        }
    }

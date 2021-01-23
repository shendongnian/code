    using System.Linq;
    //Get LatestFile  
    var directory = new DirectoryInfo("c:\\Main");
    var LatestFile = (from f in directory.GetFiles()
                 orderby f.LastWriteTime descending
                 select f).First();
    //Read contents 
     string contents = File.ReadAllText(LatestFile);

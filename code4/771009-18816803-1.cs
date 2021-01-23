        public abstract class BaseClass
    {
        public string GetResourceFilePath()
        {
            string assemblyName = Assembly.GetExecutingAssembly().FullName;
            assemblyName = assemblyName.Substring(0, assemblyName.IndexOf(','));
            string myFilePath = GetRealClassPath();
            //If base class is in the root directory, this could just be replaced by string projectFolder = GetFilePathLoc();
            string projectFolder = RootClass.GetPath();
            //Remove the "absolute part" of the path
            myFilePath = myFilePath.Substring(projectFolder.Length);
            return "/" + assemblyName + ",component/" + myFilePath;
        }
        protected abstract string GetRealClassPath();
        protected static string GetFilePathLoc([CallerFilePath] string filePath = "")
        {
            return filePath;
        }
    }
    public class Class1 :BaseClass
    {
        protected override string GetRealClassPath()
        {
            return GetFilePathLoc(); 
        }
    }

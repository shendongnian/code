        public static string GetResourceFilePath()
        {
            string assemblyName = Assembly.GetExecutingAssembly().FullName;
            assemblyName = assemblyName.Substring(0, assemblyName.IndexOf(','));
            string myFilePath = GetFilePathLoc();
            string projectFolder = RootClass.GetPath();
            //Remove the "absolute part" of the path
            myFilePath = myFilePath.Substring(projectFolder.Length);
            return "/" + assemblyName + ",component/" + myFilePath;
        }

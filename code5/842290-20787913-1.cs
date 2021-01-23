    public class CustomPathProvider : VirtualPathProvider 
    { 
        public CustomPathProvider() 
        {  
        } 
 
 
        /// <summary> 
        /// Make a judgment that application find path contains specifical folder name. 
        /// </summary> 
        /// <param name="path"></param> 
        /// <returns></returns> 
        private bool AssemblyPathExist(string path) 
        { 
            string relateivePath = VirtualPathUtility.ToAppRelative(path); 
            return relateivePath.StartsWith("~/Assembly/", StringComparison.InvariantCultureIgnoreCase); 
        } 
 
 
        /// <summary> 
        /// If we can find this virtual path, return true. 
        /// </summary> 
        /// <param name="virtualPath"></param> 
        /// <returns></returns> 
        public override bool FileExists(string virtualPath) 
        { 
            if (this.AssemblyPathExist(virtualPath)) 
            { 
                return true; 
            } 
            else  
            { 
                return base.FileExists(virtualPath); 
            } 
        } 
 
 
        /// <summary> 
        /// Use custom VirtualFile class to load assembly resources. 
        /// </summary> 
        /// <param name="virtualPath"></param> 
        /// <returns></returns> 
        public override VirtualFile GetFile(string virtualPath) 
        { 
            if (AssemblyPathExist(virtualPath)) 
            { 
                return new CustomFile(virtualPath); 
            } 
            else 
            { 
                return base.GetFile(virtualPath); 
            } 
        } 
 
 
        /// <summary> 
        /// Return null when application use virtual file path. 
        /// </summary> 
        /// <param name="virtualPath"></param> 
        /// <param name="virtualPathDependencies"></param> 
        /// <param name="utcStart"></param> 
        /// <returns></returns> 
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart) 
        { 
            if (AssemblyPathExist(virtualPath)) 
            { 
                return null; 
            } 
            else 
            { 
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart); 
            } 
        } 
    } 

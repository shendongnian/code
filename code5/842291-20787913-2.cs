    public class CustomFile: VirtualFile 
    { 
        string path 
        { 
            get; 
            set; 
        } 
 
 
        public CustomFile(string virtualPath) 
            : base(virtualPath) 
        { 
            path = VirtualPathUtility.ToAppRelative(virtualPath); 
        } 
 
 
        /// <summary> 
        /// Override Open method to load resource files of assembly. 
        /// </summary> 
        /// <returns></returns> 
        public override System.IO.Stream Open() 
        { 
            string[] strs = path.Split('/'); 
            string name = strs[2]; 
            string resourceName = strs[3]; 
            name = Path.Combine(HttpRuntime.BinDirectory, name); 
            Assembly assembly = Assembly.LoadFile(name); 
            if (assembly != null) 
            { 
                Stream s = assembly.GetManifestResourceStream(resourceName); 
                return s; 
            } 
            else 
            { 
                return null; 
            } 
        } 
    } 

    public sealed class SQLFile
    {  
        //...
        private static string sProjectName;
        public static string ProjectName
        {
            get
            {
                return sProjectName;
            }
            set
            {
                //optionally, you could prevent updates with:
                //if (string.IsNullOrEmpty(sProjectName))
                sProjectName= value;
                //else throw Exception("ProjectName was already set!");
            }
    }

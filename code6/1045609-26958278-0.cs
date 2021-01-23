    public class Config
    {
        private string path1;
        private string path2;
        public string Path1 
        { 
            get { return path1;}
            set
            {
                path1 = value;
                Path2 = string.Format("{0}bla", value);
            }
        }
      
        public string Path2 
        {
            get { return path2; }
            set { path2 = value; }
        }
        public Config()
        {
            Path1 = "testpath";
        }
    }

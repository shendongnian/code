    public class Program
    {   
        private static string DirectoryPath;
    
        public static void Main()
        {
            setPaths();
            SetGroundTempArray();
        }
    
        public static void setPaths()
        {
            DirectoryPath = Directory.GetCurrentDirectory();
        }
    
        public static void SetGroundTempArray()
        {
            string groundtempfile = "\\groundtemp.txt";
            string groundtempdir = "\\Text Files";
            string groundtempFP = DirectoryPath + groundtempdir + groundtempfile;
        }
    }

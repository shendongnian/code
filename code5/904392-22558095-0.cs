    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.Arguments = string.Join("", Constants.Arguments);
            prc.StartInfo.FileName = Constants.PathToInfoPath;
            prc.Start();
        }
    }
    public class Constants
    {
        public static string PathToInfoPath = @"C:\Program Files (x86)\Microsoft Office\Office14\INFOPATH.EXE";
        public static string[] Arguments = new string[] { @"c:\users\accountname\Desktop\HSE-000403.xml" };
    }

    using System.Diagnostics;
        
    public class MainApp
    {
        
        public static void Main(string[] args)
        {    
            string textFile = @"c:\workspace\1.txt";
            openNotepad(textFile);
            openNotepad(textFile);    
        }
        
        private static void openNotepad(string textfile)
        {         
             ProcessStartInfo f001 = new ProcessStartInfo();
             f001.FileName = "notepad.exe";
             f001.Arguments = textfile;
             f001.WindowStyle = ProcessWindowStyle.Normal;
             Process f1 = Process.Start(f001);
             f1.WaitForExit();    
         }  
    }

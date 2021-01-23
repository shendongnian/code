    using System;
    using System.IO;
    using System.Windows.Forms;
    
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Clipboard.SetDataObject(File.ReadAllText("Counter.txt"), true);
        }
    }

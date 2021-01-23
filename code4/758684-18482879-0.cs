    using System;
    using System.IO;
    using System.Windows.Forms;
    
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            using (StreamReader myFile = new System.IO.StreamReader("Counter.txt"))
            {
                Clipboard.SetDataObject( myFile.ReadToEnd(), true);
            }
        }
    }

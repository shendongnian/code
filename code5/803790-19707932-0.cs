    using System;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [STAThread]
            private static void Main(string[] args)
            {
                Console.WriteLine("Say something and it will be copied to the clipboard");
    
                var something = Console.ReadLine();
    
                Clipboard.SetText(something);
    
                Console.Read();
            }
        }
    }

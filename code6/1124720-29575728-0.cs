    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string saveFile = "test.txt";
                try
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\Channels\\" + saveFile))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\Channels\\" + saveFile);
                    }
    
                    File.Create(Directory.GetCurrentDirectory() + "\\Channels\\" + saveFile).Close();
    
                    StreamWriter streamWriter = new StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\Channels\\" + saveFile);
    
                    //safe stuff to file
                    streamWriter.Close();
    
                }
                catch (Exception ex)
                {
    
                }
            }
        }
    }

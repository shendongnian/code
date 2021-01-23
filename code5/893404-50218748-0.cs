    using System;
    
    
    namespace CreateNewFolder
    {
        class Program
        {
            static void Main(string[] args)
            {
                string Todaysdate = DateTime.Now.ToString("-dd-MM-yyyy-(hh-mm-ss)");
                
                {
                    Directory.CreateDirectory("c:/Top-Level Folder/Subfolder/Test" + Todaysdate);
                }
            }
        }
    }

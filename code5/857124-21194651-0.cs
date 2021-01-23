    static void ProcessKeyPress(ConsoleKeyInfo KeyInput)
            {
                if (KeyInput.KeyChar.Equals('1'))
                {
                    //Here's where all the varibles declerd
                    string[] filePaths = Directory.GetFiles(@"C:\\George Philip\\Projects\\TestHarness");
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        Console.WriteLine(System.IO.Path.GetFileName(path));
                    }
    
    
                }
    
    
                if (KeyInput.KeyChar.Equals('2'))
                {
                    //While begins
                    while (true)
                    {
                        Console.Write(" :Leave Blank And Press Enter To End Loop - Please Enter Extention type!: ");
    
                        //Here the file type enterd is loged ready for use! 
                        extention = Console.ReadLine();
                        //This will end the loop if the user don't input anything
                        if (String.IsNullOrEmpty(extention))
                            break;
    
                        //This where the file type the user ented is added
                        FileInfo[] files = root.GetFiles(@"*" + extention);
                        //Gets files within
                        foreach (var file in files)
                            Console.WriteLine(file.Name);
                    }
                }
    
    
                if (KeyInput.KeyChar.Equals('3'))
                {
                    // Here's where data is vollected from C:\\Windows
                    System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\\Windows");
                    Console.ReadLine();
    
                    // This helps find the file location
                    System.IO.DirectoryInfo dirInfo = di.RootDirectory;
    
                    // This displays the files in the folder loacation
                    System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");
    
                    // This shows the folder sitstics of C:\\ windows
                    foreach (System.IO.FileInfo finfo in fileNames)
                    {
                        Console.WriteLine("{0}: {1}: {2}", finfo.Name, finfo.LastAccessTime, finfo.Length);
                    }
                }
            }
    
            static void Main(string[] args)
            {
                //These are the strings that inshlise the execution of the code
                String extention = String.Empty;
                //Gets the folder location
                 DirectoryInfo root = new DirectoryInfo(@"C:\\George Philip\\Projects\\TestHarness");
    
                Console.WriteLine("Welcome Select An Option!");
                Console.WriteLine("Please Press Key 1 To List All Files In: C:\\Windows");
                Console.WriteLine("Please Press Key 1 To Filter File Types!");
                Console.WriteLine("Please Press Key 3 To Folder Statistics");
                Console.WriteLine("-------------------------------------------------------------------------------");
    
                
                // This is the code for the escape togle key
                ConsoleKeyInfo esclink;
    
                Console.WriteLine("Press Escape key to exit!");
    
                esclink = Console.ReadKey();
    
                do
                {
                    ProcessKeyPress(esclink);
    
                    esclink = Console.ReadKey();
                    
    
                    // This waits till the escape key is pressed and then takes action
                }
                while (esclink.Key != ConsoleKey.Escape);
            }

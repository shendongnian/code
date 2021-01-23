    class WriteData
        {
            static void Main(string[] args)
            {
                string nFile = @"C:\Users\Ashraf\Documents\newFilex.txt";
                FileStream fs = null;
    
                // checking if file already exists and getting user input on deleting it or not
                if (File.Exists(nFile))
                {
                    Console.WriteLine("File already exists!");
                    Console.WriteLine("What would you like to do? \n");
                    Console.WriteLine("\"DELETE\" to delete the file, or press Enter to continue ?");
                    string ans;
                    ans = Console.ReadLine();
                    switch (ans)
                    {
                        case "":
                            Console.WriteLine("continue ...");
                            break;
                        case "DELETE":
                            File.Delete(nFile);
                            if (File.Exists(nFile))
                            {
                                Console.WriteLine("Error deleting file!");
                            }
                            else
                            {
                                Console.WriteLine("File deleted successfuly");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    try
                    {
                        fs = new FileStream(nFile, FileMode.CreateNew, FileAccess.ReadWrite);
    
                        // Write Abc to file
                        for (char c = 'A'; c <= 'Z'; c++)
                        {
                            fs.WriteByte((byte)c);
                        }
    
                        Console.WriteLine("File created and data written to file successfuly");
                    }
    
                    catch (IOException ce)
                    {
                        Console.WriteLine("\t File couldn't be created! \t \n" + ce.Message);
                    }
                    finally
                    {
                        Console.Read();
                        fs.Dispose();
                    }
                }
            }
        }

    string path = @"c:\temp\MyIOFile.txt";
    
                try
                {
                    
                    string file = File.ReadAllText(path);
                    //The code wrote to the right hand side finds the file listed from my C drive
    
                    string longstr = file;
    
                    string[] strs = longstr.Split(':', '*');
    
                    foreach (string ss in strs)
                    {
                        Console.WriteLine(ss);
                    }
    
                    //before text is written, you say you want to modify it
                    string newText = "*enter new file contents here*";
    
                    //you can add new text (Append) or
                    //change all the contents of the file
                    //set the value of whatToDo to "Append" to add new text to the file
                    //set the value of whatToDo to any value other than "Append" to replace
                    //the entire contents of the filw with the data in variable newText
                    string whatToDo = "Append";
    
                    if (whatToDo == "Append")
                    {
                        //append to existing text
                        //variable file contains old text
                        //varaible newText contains the new text to be appended
                        File.AppendAllText(path, newText);
                    }
                    else
                    {
                        //creates new contents in the file.
                        //varaiable new text contains the new text representing
                        //file contents
                        File.WriteAllText(path, newText);
                    }
    
    
                    //string file = File.AppendAllText(@"C:\Users\path\.......");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*** Error:" + ex.Message);
                }
                Console.WriteLine("*** Press Enter key to exit");
                Console.ReadLine();
            }

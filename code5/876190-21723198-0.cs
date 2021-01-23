    foreach (string fileName in Directory.GetFiles("Folder","*.eps"))
                {
                    using (MagickImage image = new MagickImage())
                    {
                        Console.WriteLine("\n\nNow Converting. Please Wait...\n\n");
                        image.Read(fileName, settings);
                        string[] split = filename.Split('\\');
                        string clear_file_name = split[split.Length-1];
                        string split_file_name= clear_file_name.split('.');
                        string filename_without_extention = split_file_name[0];  
                        if(!Directory.Exists(folder+"\\jpeg"))
                            Directory.Create(folder+"\\jpeg");
                        image.Write(fileName.Substring(0,folder+"\\jpeg\\"+file_name_without_extention+".jpg");
                        i++;
                        Console.WriteLine("Conversion Success.\n\n");
                        Console.WriteLine("Files Converted: " + i); 
                    }
                }

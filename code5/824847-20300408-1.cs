                String path=@"C:\IDFolder";
                
                String [] files= System.IO.Directory.GetFiles(path);
                List<String> ID=new List<string>();
                List<String> Password=new List<string>();
                List<String> Name=new List<string>();
                int count=0;
               
                foreach (String strFileName in files)
                {
                   count=0;
                   String[] allLines = System.IO.File.ReadAllLines(strFileName);
                   foreach (String line in allLines)
                   {
                      
                        
                       if (allLines[count].Split('/').Length==3)
                       {
                           ID.Add(allLines[count].Split('/')[0]);
                           Password.Add(allLines[count].Split('/')[1]);
                           Name.Add(allLines[count].Split('/')[2]);
                           count++;
                       }
                      
                   }
                }

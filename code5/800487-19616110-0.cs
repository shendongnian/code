            StringBuilder sb = new StringBuilder();
           //read the line by line of file.txt
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    //for each line identify the space
                    //cut the data from beginning of each line to where it finds space
                    string str = line.Substring(0, line.IndexOf(' '));
                    //Append each modifed line into string builder object
                    sb.AppendLine(str);
                }
            }
           
            //Create temp newfile
            using (File.Create("newfile.txt"))
            {
                //create newfile to store the modified data
            }
            
            //Add modified data into newfile
            File.WriteAllText("newfile.txt",sb.ToString());
            //Replace with new file
            File.Replace("newfile.txt", "file.txt", null);

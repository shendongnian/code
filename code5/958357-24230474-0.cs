    void ModRec()       
    {     
            string filename = @"C:\Current\EmployeeDetails.txt";
            string current = @"C:\Current\";
            string history = @"C:\History\";
            FileInfo fileinfo = new FileInfo(filename);
            if (fileinfo.Exists)
            {
                if (!Directory.Exists(history))
                {
                    Directory.CreateDirectory(history);
                }
            }
            else
            {
                Console.WriteLine("\t\t\tFile doesn't exist!");
                Console.ReadLine();
                Menu1();
            }
            var extension = Path.GetExtension(filename);
            var fileNamePart = Path.GetFileNameWithoutExtension(filename); 
	        var path = Path.GetDirectoryName(filename); 
	        var version = 0; 
	        string result;
            do
            {
                version++;
                result = Path.Combine(history, fileNamePart + "_" + version + extension); 
	        }
            while (File.Exists(result));
            File.Move(filename, result);
        }

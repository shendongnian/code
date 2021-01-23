    if (File.Exists(file) == true)
        {
            StreamReader rdr = new StreamReader(file);
            string myString = rdr.ReadToEnd();
    
            if (myString == null)
            {
                Console.WriteLine("File empty");
                return false;
            }
            else { Console.WriteLine(myString); return true; }
        }
     return false; ///<=============

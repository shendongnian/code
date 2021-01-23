    using System;
    using System.IO;
    
    class Test 
    {
    
        public static void Main() 
        {
            string txtpath = @"c:\textfile.txt";
            try 
            {
                if (File.Exists(txtpath)) 
                {
    
    
    
                using (StreamReader sr = new StreamReader(txtpath)) 
                {
                    while (sr.Peek() >= 0) 
                    {
                        string ss = sr.ReadLine();
                         string [] txtsplit = ss.Split(';');
    
                         //now loop through   array
                         string server=txtsplit[0].Tostring();
                        string userid= split[1].Tostring(); // user id
                       string password= split[2].Tostring(); // password
    
                    }
                }
              }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }
    }

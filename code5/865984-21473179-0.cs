           String line;
           int counter = 0;
           Boolean isFirstLine = true;
           try
           {
               
               StreamReader sr = new StreamReader("C:\\Files\\gamenam.txt");
               
               StreamWriter sw = new StreamWriter("C:\\Files\\gamenam_1.txt");
 
 
               while ((line = sr.ReadLine()) != null)
               {
 
 
                   
                   if (line.Substring(0, 2) == "01")
                   {
                       if (!isFirstLine)
                       {
                           sw.WriteLine(counter.ToString());
                           counter = 0;
                           
                       }
                       
                       
 
                   }
 
                   if (line.Substring(0, 2) == "05")
                   {
 
 
                       counter++;
 
                   }
                   sw.WriteLine(line);
 
                   if (sr.Peek() < 0)
                   {
                       sw.Write(counter.ToString());
 
                   }
                   
                   isFirstLine = false;
               }
 
               
               sr.Close();
               sw.Close();
           }
           
           catch (Exception e)
           {
               
               Console.WriteLine("Exception: " + e.Message);
           }
           finally
           {
               Console.WriteLine("Exception finally block.");
           }
       }
 

    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
   {
 
         yield return line;
       }
   
    file.Close();

    using System.IO; //import this namespace. 
    String [] strFile1=File.ReadAllLines("file1.txt");
    String [] strFile2=File.ReadAllLines("file2.txt");
      if(strFile1.Length==strFile2.Length)
      {
        for(int i=0;i<strFile1.Length;i++)
         {
           if(!strFile1[i].Equals(strFile2[i]))
            {
               Console.WriteLine(strFile2[i]);
            }
         }
       }

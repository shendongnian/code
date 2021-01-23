    string l1, l2, l3, l4;
    StreamReader sr = new StreamReader(sourcePath);
    l1 = sr.Readline(); // Line 1
    l2 = sr.Readline(); // Line 2
    l3 = sr.Readline(); // Line 3
 
      public string StreamReadLine(string sourcepath, int lineNum)
        {
          int index = lineNum;
          string strLine = "N/A";
          StreamReader sr = new StreamReader(sourcepath);
         try
        {
           for (var i = 0; i <= index; i++)
           {
             strLine = sr.ReadLine();
             if (i == index)
                 break;
             i += 1;
           }
       }
       catch (Exception ex)
       {
         strLine = ex.ToString();
       }
    return strLine;
}
 

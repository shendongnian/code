    List<string> rt = new List<string>();
    bool doAdd = true;
    foreach (string line in richTextBox1.Lines)
    {
       if(doAdd)
       {
         rt.Add(line);
         doAdd = true;
       }
 
       if (string.IsNullorEmpty(line))
       {          
          doAdd = false;
       }
       else
       {
         doAdd = true;
       }
    }

    public void skip10Lines()
    { 
        StringBuilder lines=new StringBuilder();
        using(StreamReader sr = new StreamReader(path))
        {
         String line = "";
         int count=0;
        
          while((line= sr.ReadLine())!=null)
          {
             if(count==10)
               break;
             lines.Append(line+Environment.NewLine);
             count++;
          }
         }
     string myFileData=lines.ToString();
     }

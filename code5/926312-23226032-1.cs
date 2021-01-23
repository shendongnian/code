    var fileArray = File.ReadAllLines(myLocation);
    
        for(int i=0;i< line<fileArray.Length;i++)
        {
           if (i == 0)
           {  
              \\handle column names
           }
           else
           {
             var columns = line.Split('\t')
             string value = columns[3];
           }
        }

    using System.IO;
    
    class FileData
    {
    public string Column2{ get; set; }
    public string Column12{ get; set; }
    public string Column45{ get; set; }
    }
   
    
    List<FileData> filedata =  new List<FileData>();
    
     FileData temp = new FileData();
     foreach(var line in File.ReadLines("filepath.txt").Skip(1))
     {     
       var tempLine = line.Split('\t');
       temp.Column2 = tempLine[1];
       temp.Column12 = tempLine[11];
       temp.Column45 = tempLine[44]; 
       filedata.Add(temp);
     }
      
    

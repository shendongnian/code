    System.IO.FileStream fs = new System.IO.FileStream(txtFilePath.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read,System.IO.FileShare.ReadWrite);  
     
    System.IO.StreamReader sr = new System.IO.StreamReader(fs);  
 
    List<String> lst = new List<string>();  
 
    while (!sr.EndOfStream)  
         lst.Add(sr.ReadLine());  

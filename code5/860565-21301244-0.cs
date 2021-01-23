        using System.Text.RegularExpressions;
        using System.IO;
        using System.Text;
        
    string pattern = "^3/1/2014.*"; 
        string strPath = new string("c:\\"); 
        string strDateTime = DateTime.Now.ToString("yyyyMMdd"); 
        string FileToCopy = "c:\\regexTest.txt"; 
        string NewCopy = strPath + strDateTime + ".txt"; 
        StringBuilder sb = new StringBuilder(""); 
        List<string> newLines = new List<string>(); 
        
        if (System.IO.File.Exists(FileToCopy) == true) { 
        string[] lines = File.ReadAllLines(FileToCopy); 
        foreach (string line in lines) { 
        if (Regex.IsMatch(line, pattern)) { 
        sb.Append(line + System.Environment.NewLine); 
        } 
        } 
        } 
        
        if (sb.Length > 0) { 
        System.IO.File.WriteAllText(NewCopy, sb.ToString); 
        }

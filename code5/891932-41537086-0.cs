    using System.IO;
    
    //  
    
        string readStr = File.ReadAllText(file.FullName);          
        string[] read = readStr.Split(new char[] {'\r','\n'},StringSplitOptions.RemoveEmptyEntries);

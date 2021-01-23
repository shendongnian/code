    using System.Io;
    
    using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
    using (StreamWriter sw = new StreamWriter(fs))
    {
    while (readerObj.Read())
    {
    string something = "";
    sw.writeline(something);
    }
    }

    var lines = new List<string>();
    for(int i=count+1; i<= antall22; i++)
    {
         lines.Add(string.Format("FileSpec_{0}=C:\Solid4.2\solid.{0} 1000m",i));
    }
    File.WriteAllLines(filepath,lines);

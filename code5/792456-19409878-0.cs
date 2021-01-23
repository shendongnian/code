    string[] lines = File.WreadAllLines("file.txt");
    int lastnum;
    for(int i=0;i<lines.Count;i++)
        lines[i]=System.Text.RegularExpressions.Regex.Replace(lines[i], @",(\d+)$", m => 
        { 
            lastnum = Convert.ToInt32(m.Groups[1].Value);
            // Do any operations on lastnum
            return "," + lastnum.ToString(); 
        });
    
    File.WriteAllLines("file.txt",lines);

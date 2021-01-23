    var lines = File.ReadAllLines("DNA.txt");
    for(int i=0;i<lines.Count();i+=5)
    {
        lstOut.Items.Add(string.Format("Line {0}:{1}",
                         (i/5).ToString("00"),
                         string.Join(" ",lines.Skip(i).Take(5))));
    }

    if (File.Exists("startapp.txt")
    {
        using (StreamWriter writeFile = new StreamWriter("startapp.txt"));
        {
            StreamReader sr = new StreamReader("startapp.txt"); 
            int count = int.Parse(sr.ReadToEnd());
            sr.Close();
            count++;
            writeFile.WriteLine(count.ToString());
        }
    }
    else
    {
        FileStream fs = File.Create("startapp.txt");
        fs.Close();
        File.SetAttributes(
        "startapp.txt", 
        FileAttributes.Archive | 
        FileAttributes.Hidden | 
        );
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("1");
    }

    // Use File.ReadAllLines, it's easier
    string[] lines = File.ReadAllLines("test.txt");
    foreach(line in lines)
    {
       var text = line.Split('\t','\n');
       dataGridView1.Rows.Add(text);
    }
     

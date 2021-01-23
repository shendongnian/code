    string[] text = System.IO.File.ReadAllLines(file);
    int current = 0;
    foreach (string line in text)
    {
       if (current <= text.Length / 2)
       {
          listBox1.Items.Add(line);
       }
       else
       {
          listBox2.Items.Add(line);
       }
       
       current++;
    }

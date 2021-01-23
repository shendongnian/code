    using(StremReader sr = new StreamReder(filePath))
    {
      while(!sr.EndOfStream)
      {
        string line = sr.ReadLine();
        string[] items = line.Split(' ');
    
        listBox0.Items.add(items[0]);
        listBox1.Items.add(items[1]);
        listBox2.Items.add(items[2]);
       }
    }

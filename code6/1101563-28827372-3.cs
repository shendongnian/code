    for(int i=0; i<listBox.Count; i++)
    {
      string line = String.Format("{0},{1}", listBox1.Items[i], listBox2.Items[i]);
      SaveFile.WriteLine(line);
    }

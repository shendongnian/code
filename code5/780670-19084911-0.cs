    while (!sr.EndOfStream)
    {
      if (i > 8)
      {
        textBox1.Text = sr.ReadLine(); 
        break;
      }
    
      sr.ReadLine();
      i++;
    }

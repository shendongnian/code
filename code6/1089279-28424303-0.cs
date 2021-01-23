    using(StreamReader sr = new StreamReader(stylePath))
    {
       string line, color;
       string[] items;
       int row, cell;
    
       while(!sr.EndOfStream)
       {
          line = sr.ReadLine();
          items = line.Split(';');
          if(items.Length<3) continue; //something wrong in the file
    
          row = Convert.ToInt32(items[0]);
          cell = Convert.ToInt32(items[1]);
          color = items[2];
    
          dataGridView1.Rows[row].Cells[cell].Style.BackColor = Color.FromName(color);
       }
    }

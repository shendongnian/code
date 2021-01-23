    using(StreamReader sr = new StreamReader(stylePath))
    {
       string line;
       string[] items;
       int row, cell;
       Color color;
    
       while(!sr.EndOfStream)
       {
          line = sr.ReadLine();
          items = line.Split(';');
          if(items.Length<3) continue; //something wrong in the file
    
          row = Convert.ToInt32(items[0]);
          cell = Convert.ToInt32(items[1]);
          if(String.IsNullOrEmpty(item[2])) continue; // No change is needed
          color = Color.FromName(items[2]);
    
          dataGridView1.Rows[row].Cells[cell].Style.BackColor = color;
       }
    }

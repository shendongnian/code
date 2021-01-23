          TextReader tr = File.OpenText(textBox1.Text);
          string line;
          while ((line = tr.ReadLine()) != null)
          {
              string[] parts = line.Split('|');
             if(parts.Count() == 4)
              {
                string sql1 = "INSERT INTO Info(Name,Address,Age,Sex) select '" + parts[0] + "','" + parts[1]  + "','" + parts[2]  +"','" + parts[3]  +"'  ";
              SQLcode.DoInsert(sql1);
              }
              else
              {
                // values are more than specified columns.
              }
          }

         List<int> toBeDeleted = new List<int>();
          for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Empty = true;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null && dataGridView1.Rows[i].Cells[j].Value.ToString() != "")
                    {
                        Empty = false;
                        break;
                    }
                }
                if (Empty)
                {
                    toBeDeleted.Add(i);
                }
            }
          foreach(var f in toBeDeleted)
         {
             dataGridView1.Rows.RemoveAt(f);
           }

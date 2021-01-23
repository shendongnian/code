     if (!listBox5.Items.Contains(id + "-" + pass + "-" + room + "-" + remoter + "-" + roompass))
         {
             listBox5.Items.Add(id + "-" + pass + "-" + room + "-" + remoter + "-" + roompass);
             Console.WriteLine("NOT THERE ");
                    
             form1.dataGridView1.Rows.Insert(0, id, pass, room, remoter, roompass);
         }

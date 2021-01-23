     private void button1_Click(object sender, EventArgs e)
     {
          if (listBox1.SelectedItem != null)
          {
              // Check for existence and add if it's a new item 
              if (!listBox2.Items.Contains(listBox1.SelectedItem))
              {
                        listBox2.Items.Add(listBox1.SelectedItem);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex); 
               }
           }
      }
            
      private void Form1_Load(object sender, EventArgs e)
      {
                listBox1.Items.Add("Orange");
                listBox1.Items.Add("Pineapple");
                listBox1.Items.Add("Pineapple"); // <= Simply add this repetitive item
      }
    
      private void listBox1_MouseDown(object sender, MouseEventArgs e)
      {
             if (listBox1.SelectedItem != null)
             {
                    listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);
                }
      }
    
      private void listBox2_DragEnter(object sender, DragEventArgs e)
      {
             if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    e.Effect = DragDropEffects.Move;
                }
      }
    
      private void listBox2_DragDrop(object sender, DragEventArgs e)
      {
                string strText = "";
    
                if (e.Data.GetDataPresent(DataFormats.Text))
                {
                    strText = (string)e.Data.GetData(DataFormats.Text);
                }
    
                // Check for existence and add if it's a new item 
                if (!listBox2.Items.Contains(listBox1.SelectedItem))
                {
                    listBox2.Items.Add(strText);
                    listBox1.Items.Remove(strText);
                }
       }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selected = listBox1.SelectedItem;
                index = listBox1.SelectedIndex;
                control = 1;
                DoDragDrop(selected.ToString(), DragDropEffects.Move);
            }
            else
                index = -1;
        }
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                selected = listBox2.SelectedItem;
                index = listBox2.SelectedIndex;
                control = 2;
                DoDragDrop(selected.ToString(), DragDropEffects.Move);
            }
            else      
                index = -1;
        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;    
        }
        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;            
        }
        private void listBox1_DragDrop(object sender, EventArgs e)
        {
            if (control == 2 && index != -1)
            {
                listBox2.Items.RemoveAt(index);
                listBox1.Items.Add(selected);
            }  
        }
        private void listBox2_DragDrop(object sender, EventArgs e)
        {
            if (control == 1 && index != -1)
            {
                listBox1.Items.RemoveAt(index);
                listBox2.Items.Add(selected);
            }       
        }
 

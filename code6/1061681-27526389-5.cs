        public object selected = null;
        public int index = -1;
        public int? control = null;
        /*
         *  Send items dragging them
         */
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable DoDragDrop for enabling DoubleClick event
            if (e.Clicks > 1)
                return;
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
            // Disable DoDragDrop for enabling DoubleClick event
            if (e.Clicks > 1)
                return;
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
        /*         
         *  Send items by DoubleClick
         * /
       private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
               string selected =  listBox1.SelectedItem.ToString();
               int index = listBox1.SelectedIndex;
               listBox2.Items.Add(selected);
               listBox1.Items.RemoveAt(index);
            }       
        }
     
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selected = listBox2.SelectedItem.ToString();
                int index = listBox2.SelectedIndex;
                listBox1.Items.Add(selected);
                listBox2.Items.RemoveAt(index);
            } 
        }

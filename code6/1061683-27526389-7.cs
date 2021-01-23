        // (from,to) ListBox 
        private void moveItems(ListBox lbA, ListBox lbB)
        {
            lbB.Items.Add(selected);
            lbA.Items.RemoveAt(index);
        }
        // (from,to) ListBox 
        private void moveItemsByName(string lbName1, string lbName2)
        {
            ListBox lb1 = Controls[Controls.IndexOfKey(lbName1)] as ListBox;
            ListBox lb2 = Controls[Controls.IndexOfKey(lbName2)] as ListBox;
            if (lb1.SelectedItem != null)
            {
                selected = lb1.SelectedItem.ToString();
                index = lb1.SelectedIndex;
                moveItems(lb1, lb2);                
            }
        }
  
        #region DoubleClick
        /*         
         *  Send items by DoubleClick
         */
        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            ListBox lb_sender = sender as ListBox;
            moveItemsByName(lb_sender.Name, (lb_sender.Name == "listBox1" ? "listBox2" : "listBox1"));
        }
        #endregion
        #region Drag-and-drop
        /*
         *  Send items dragging them
         */
        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;
            ListBox lb_sender = sender as ListBox;
            if (lb_sender.SelectedItem != null)
            {
                selected = lb_sender.SelectedItem;
                index = lb_sender.SelectedIndex;
                control = lb_sender.Name;
                DoDragDrop(selected.ToString(), DragDropEffects.Move);
            }
            else
                index = -1;
        }
        private void listBox_DragEnter(object sender, DragEventArgs e)
        { e.Effect = DragDropEffects.Move; }
        private void listBox1_DragDrop(object sender, EventArgs e)
        {   
            if (control == "listBox2" && index != -1)
            {
                moveItems(listBox2, listBox1);
            } 
        }
        private void listBox2_DragDrop(object sender, EventArgs e)
        {
            if (control == "listBox1" && index != -1)
            {
                moveItems(listBox1, listBox2);
            } 
        }
        #endregion        
        #region forward / backward arrows
        /*
         *  Send items by clicking arrows
         */
        private void lbArrow_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lbArrowForward))
                moveItemsByName("listBox1", "listBox2");
            else
                moveItemsByName("listBox2", "listBox1");
        }
        #endregion
    }

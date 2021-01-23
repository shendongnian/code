        private object selected = null;
        private int index = -1;
        private int? control = null;
        private ListBox[] lbs;
        private IDictionary<string, int> lb_dic;
        private void Form_Load(Object sender, EventArgs e)
        {
            // creo arrays, diccionarios,...
            lbs = new ListBox[2];
            lb_dic = new Dictionary<string, int>();            
            // registro los listbox 
            registerListbox();
            
            // valores iniciales (de prueba)
            string[] row1 = { "Manzanas", "Peras", "Naranjas" };
            listBox1.Items.AddRange(row1);
            string[] row2 = { "Pitayas" };
            listBox2.Items.AddRange(row2);
        }
        // (from,to) ListBox 
        private void moveItems(int lbx1, int lbx2)
        {        
            if (lbs[lbx1].SelectedItem != null)
            {
                selected = lbs[lbx1].SelectedItem.ToString();
                index = lbs[lbx1].SelectedIndex;
                lbs[lbx2].Items.Add(selected);
                lbs[lbx1].Items.RemoveAt(index);
            }
        }
        // (from,to) ListBox 
        private void moveItemsByListboxName(string lb1, string lb2)
        {
            moveItems(lb_dic[lb1], lb_dic[lb2]);            
        }
                
        private void registerListbox()
        {
            // registro listboxes 
            lbs[0] = this.listBox1;
            lbs[1] = this.listBox2;
            // registro listboxes en hashtable            
            lb_dic["listBox1"] = 0;
            lb_dic["listBox2"] = 1;
        }
        #region DoubleClick
        /*         
         *  Send items by DoubleClick
         */
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            moveItems(0,1);
        }
       
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            moveItems(1, 0); 
        }
        #endregion
                
        #region Drag-and-drop
        /*
         *  Send items dragging them
         */
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // disable DoDragDrop for enabling DoubleClick
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
            // disable DoDragDrop for enabling DoubleClick
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
       
        #endregion
        private void lbArrowForward_Click(object sender, EventArgs e)
        {
            moveItemsByListboxName("listBox1", "listBox2");
        }
        private void lbArrowBackward_Click(object sender, EventArgs e)
        {
            moveItemsByListboxName("listBox2", "listBox1");
        }

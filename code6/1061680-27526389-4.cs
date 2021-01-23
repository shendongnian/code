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

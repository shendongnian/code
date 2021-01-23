    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = string.Empty;
            if(listBox1.SelectedIndex != -1) 
               s = listBox1.SelectedItem.ToString();
            /// continue you code here .... 
            /// 
            /// after that remove the hilight 
            listBox1.SelectedIndex = -1;
        }

    // you can try this
    
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
                     for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {
        
                               if (checkedListBox1.GetItemChecked(i) == true)
                                {
                               textBox1.AppendText("Item is marked: " +checkedListBox1.Items[i].ToString()+ "\n");
                                  RegBUP.SetValue(checkedListBox1.Items[i]);
                                }
                               else
                                 {
                                     RegBUP.DeleteValue(checkedListBox1.Items[i]);
                                 }
                            }
        }

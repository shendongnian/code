    private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            foreach (string item in listBox1.Items)
            {
                listBox1.SelectionMode = SelectionMode.One;
                
                    if (item == comboBox1.Text)
                    {
                        result = item;
                    }
                
            }
            listBox1.SelectedItem = result;
           
        }
    

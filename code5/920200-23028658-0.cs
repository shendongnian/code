    private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Trim() =="")
            {
                MessageBox.Show("Campul este liber!");
                return;
    
            }
            //ListBox li = sender as ListBox;
    
    
            ListBoxItem li = new ListBoxItem();
            li.Content=textBox1.Text;
            textBox1.Clear();
            listBox1.Items.Add(li);
    
            textBox1.Focus();
    
    
    
    
        }

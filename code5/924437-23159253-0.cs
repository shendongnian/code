        double total = 0;
        for (int i = 0; i < listBox1.SelectedItems.Count; i++)
        {
            total += Double.Parse(listBox1.SelectedItems[i].ToString());
        }
        MessageBox.Show("The average is: " + total / listBox1.SelectedItems.Count);

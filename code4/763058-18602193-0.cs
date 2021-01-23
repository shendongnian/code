        private void listBox1_SelectionIndexChanged(object sender,EventArgs e)
        {
        string item = listBox1.SelectedItem.ToString();
        int index = item.LastIndexOf('.');
        if (index >= 0)//It's a valid file
        {
            string filename = item.Substring(0, index );
            MessageBox.Show(filename);
        }
        else if (index == -1)//Not a valid file
        {
            MessageBox.Show("The selected file is invalid.");
        }
        }

    public void AddToListBoxButton(object sender, EventArgs e)
    {
        myListBox.Items.Add(myTextBox.Text);
        using (StreamWriter sw = new StreamWriter("ListBoxItems.txt",true))
        {
            sw.WriteLine(myTextBox.txt);
        }
    }

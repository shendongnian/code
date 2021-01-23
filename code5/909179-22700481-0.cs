    private btnFind_Click(Object sender, EventArgs e)
    {
        if(FindText(textBoxFind.Text))
        {
            MessageBox.Show("Found Match!");
        }
        else
        {
            MessageBox.Show("Didn't found match...");
        }
    }

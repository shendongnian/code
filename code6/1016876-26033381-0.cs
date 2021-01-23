    private void btnRmv_Click(object sender, EventArgs e)
    {
        try
        {
            people.RemoveAt(listBox.SelectedIndex);
            listBox.Items.Remove(listBox.SelectedItems[0]);
        }
        catch { }
    }

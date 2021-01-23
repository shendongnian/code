    private void button3_Click(object sender, EventArgs e)
    {
        if(lstItemCode.SelectedItem != null)
        {
            string newText = lstItemCode
                                .SelectedItem
                                .ToString()
                                .Replace("Complete", string.Empty)
                                .Trim();
            lstItemCode.Items[lstItemCode.SelectedIndex] = newText;
        }
    }

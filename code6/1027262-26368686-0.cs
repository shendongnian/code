    private void button1_Click(object sender, EventArgs e)
    {
        StringBuilder skills = new StringBuilder();
        foreach (object item in listBox1.SelectedItems)
        {
            skills.AppendLine(item.ToString());
        }
        MessageBox.Show("You have selected following Skills : \n" + skills.ToString(), "Selected Skills",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

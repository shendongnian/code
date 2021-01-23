    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        Skill = checkedListBox1.SelectedItem.ToString();
        if (e.NewValue == CheckState.Checked)
        {
            listBox1.Items.Add(Skill);
        }
        else
        {
            listBox1.Items.Remove(Skill);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("You have selected following Skills : \n"+ listBox1.Items.Cast<string>().Aggregate((o, n) => o.ToString() + "," + n.ToString()), "Selected Skills",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

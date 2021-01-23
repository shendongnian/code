    private void button1_Click(object sender, EventArgs e)
    {
        var selectedSkills = checkedListBox1.SelectedItem.ToString();
        MessageBox.Show("You have selected following Skills : \n"+selectedSkills, "Selected Skills",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

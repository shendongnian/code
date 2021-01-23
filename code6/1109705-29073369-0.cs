    private void button1_Click(object sender, EventArgs e)
    {
        ToolStripDropDown dropDown = new ToolStripDropDown();
        ListBox listBox = new ListBox();
        for (int i = 0; i < 10; i++)
        {
            listBox.Items.Add("Item " + i);
        }
        listBox.SelectedIndexChanged += (o, args) => dropDown.Close();
        dropDown.Items.Add(new ToolStripControlHost(listBox));
        dropDown.Show(MousePosition);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var parentTabControl = new TabControl {Dock = DockStyle.Fill};
        parentTabControl.TabPages.Add("Parent Tab");
        var page = parentTabControl.TabPages[0]; // Get the index that is appropriate for your logic
        var childTabControl = new TabControl {Dock = DockStyle.Fill};
        childTabControl.TabPages.Add("Child Tab");
        page.Controls.Add(childTabControl);
        this.Controls.Add(parentTabControl);
    }

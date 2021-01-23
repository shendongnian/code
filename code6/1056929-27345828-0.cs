    void TestPanel2_ControlAdded(object sender, ControlEventArgs e)
    {
        if (e.Control != innerPanel) {
            this.Controls.Remove(e.Control);
            innerPanel.Controls.Add(e.Control);
        }
    }

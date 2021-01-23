    private void offToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GroupBox v = (GroupBox)sender;
        foreach (Control g in Controls)
        {
            if (g is GroupBox) // only if g is a GroupBox set Visible to false
                g.Visible = false;
        }
    }

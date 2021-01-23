    private void optionToolStripMenuItem_Click(object sender, EventArgs e)
    {
    
        DGV1.Visible = false
    
         DialogResult res = MessageBox.Show("Are You Sure?", "Are You Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
               ......
        }
    }

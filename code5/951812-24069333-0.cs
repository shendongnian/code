    ContextMenuStrip cms = new ContextMenuStrip();
    private void button4_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            cms.Items.Add("Test Menu");
            cms.Show(button4.PointToScreen(e.Location));
        }
    }

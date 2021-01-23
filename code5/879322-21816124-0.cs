    private void textBox1_MouseDown(object sender, MouseEventArgs e)
    {
        textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
    }
    private void tabControl1_DragOver(object sender, DragEventArgs e)
    {
        Point location = tabControl1.PointToClient(Control.MousePosition);
        for (int tab = 0; tab < tabControl1.TabCount; ++tab)
        {
            if (tabControl1.GetTabRect(tab).Contains(location))
            {
                tabControl1.SelectedIndex = tab;
                break;
            }
        }
    }
    private void textBox2_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.Text))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }
    private void textBox2_DragDrop(object sender, DragEventArgs e)
    {
        textBox2.Text = e.Data.GetData(DataFormats.Text).ToString();
    }

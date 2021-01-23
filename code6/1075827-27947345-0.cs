    private void lvImageFolder_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            //txtCursor.Text = Cursor.Position.ToString();
            if (lvImageFolder.SelectedItems.Count > 0)
            {
                var lst = new List<string>();
                foreach (ListViewItem item in lvImageFolder.SelectedItems)
                {
                    lst.Add(item.Text);
                }
                lvWebServer.DoDragDrop(lst, DragDropEffects.Move);
            }
        }
    }
    private void lvWebServer_DragDrop(object sender, DragEventArgs e)
    {
        List<string> lst = e.Data.GetData(typeof(List<string>)) as List<string>;
        foreach (var item in lst)
        {
            lvWebServer.Items.Add(item);
        }
            
    }
    private void lvWebServer_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(List<string>)))
        {
            e.Effect = DragDropEffects.Move;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    delegate void DeselectDelegate();
    public void DeselectItem()
    {
        if (this.listView1.InvokeRequired)
        {
            DeselectDelegate del = new DeselectDelegate(DeselectItem);
            this.Invoke(del);
        }
        else
        {
            listView1.SelectedItems[0].Selected = false;
        }
    }
    private void SelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (e.IsSelected)
        {
            DialogResult GetDialogResult =
                    MessageBox.Show("Keep this item selected?",
                    "Keep Selected",
                    MessageBoxButtons.YesNo);
            if (GetDialogResult == DialogResult.No)
            {
                Thread thread = new Thread(DeselectItem);
                thread.Start();
            }
        }
    }

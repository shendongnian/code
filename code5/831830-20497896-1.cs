    foreach(Control c in form.Controls)
    {
        if(c is CheckBox)
        {
            CheckBox cb = (CheckBox)c;
            
            if(cb.Checked)
            {
                ListViewItem item = new ListViewItem(cb.Text);
                yourListView.Items.Add(item);
            }
        }
    }

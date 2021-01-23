    string[] array = { "Dress", "Pen", "Table"};
    for (int i = 0; i < chkbx.Items.Count; i++)
    {
        if (array.Contains(chkbx.Items[i].Text))
        {
            chkbx.Items[i].Selected = true;
        }
    }

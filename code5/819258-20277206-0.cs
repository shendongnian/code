    Person person = new Person();
    try { person = FindPerson(listView1.SelectedItems[0].Text); } catch { return; }
    if (listView1.SelectedItems.Count > 0)
    {
    try
    {
    if (listView1.SelectedItems.Count == 0) return;
    foreach (ListViewItem eachItem in listView1.SelectedItems)
    {
    people.RemoveAll(x => x.Name == eachItem.Text);
    listView1.Items[listView1.Items.Count - 1].Selected = true;
    listView1.Items.Remove(eachItem);
    }
    }
    catch { }
    ClearAll();
    ReadOnlyON();
    }
    else
    {
    MessageBox.Show("Nothing is selected!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

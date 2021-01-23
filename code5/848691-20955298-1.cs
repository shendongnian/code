    var newList = new ArrayList();
    foreach (object item in listBox1.Items)
    {
        newList.Add(item);
    }
    Properties.Settings.Default.listboxItems = newList
    Properties.Settings.Default.Save();

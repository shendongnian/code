    web.AllowUnsafeUpdates = true; 
    SPList list = web.Lists.TryGetList(ListName);
    SPListItem newItem = list.Items.Add();
    // notice that Project Name Column still referring to Title column even though we have changed that 
    newItem["Title"] = textBox1.Text;
    newItem.Update();
    web.allowUnsafeUpdates = false;

    // store CSV list of indices
    Settings.Default["SelectedItems"] = String.Join(",", listView.SelectedIndices.Select(x => x));
    ...
    // load selected indices
    var selectedIndices = ((string)Settings.Default["SelectedItems]).Split(',');
    foreach (var index in selectedIndices)
    {
        listView.Items[Int32.Parse(index)].Selected = true;
    }
 
     

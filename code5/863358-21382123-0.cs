    // get the list ...
    var list = c.ToDoLists.ToList();
    Debug.Assert(list != null);
    // clear any existing items, which will in turn remove all items from the UI
    App.ViewModel.Items.Clear();
    // for each item in the list, add it to the existing bound Items list
    foreach(var item in list) {
       // you may need to transform the data here
       // The item must be the right type ...
       App.ViewModel.Items.Add(item);
    }
    

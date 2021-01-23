    private void tvView_SelectedIndexChanged(object sender, EventArgs e) {
        // cast your TreeView to ObjectListView to access the selected Object
        ObjectListView olv = sender as ObjectListView;
        // get the selected child (you may want to check the type and if it really was a child that was selected here)
        MyChildModelObject child = olv.SelectedObject as MyChildModelObject;
        MyParentModelObject parent = _tvView.GetParent(child);
         
        // ...
    }

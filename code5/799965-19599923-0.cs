    //Inside TableView
    private void Callback(List<MyObject> objects) {
        InvokeOnMainThread(() => {
            ((MyTableViewSource)TableView.Source).AddObjects(objects);
            TableView.ReloadData();
        });
    }

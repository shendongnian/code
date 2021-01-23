public ObservableCollection<object> bindedObservableCollection
{
    get{
        ObservableCollection<object> newlist = new ObservableCollection<object>(yourObservableCollection);
        return newlist;
    }
}
I had this issue when binding to a list that was part of a datagrid, I found casting it to a new list of same type removed the blank editors record that is part of the datagrid.

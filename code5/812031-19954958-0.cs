    void ListBoxItem_Drop(object sender, DragEventArgs e)
    {
        object Target = ((ListBoxItem)(sender)).DataContext;
        object Dropped = e.Data.GetData(Target.GetType());
        int RemoveIndex = listbox1.Items.IndexOf(Dropped);
        int TargetIndex = listbox1.Items.IndexOf(Target);
        ListBox container = ((DependencyObject)sender).GetAncestor<ListBox>();
        IList IList = (IList)container.ItemsSource;
        if (RemoveIndex < TargetIndex)
        {
            IList.Insert(TargetIndex + 1, Dropped); 
            IList.RemoveAt(RemoveIndex);
        }
        else
            if (IList.Count > RemoveIndex)
            {
                IList.Insert(TargetIndex, Dropped);
                IList.RemoveAt(RemoveIndex + 1);
            }
    }

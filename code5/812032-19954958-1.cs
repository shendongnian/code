    void ListBoxItem_Drop(object sender, DragEventArgs e)
    {
        object Target = ((ListBoxItem)(sender)).DataContext;
        object Dropped = e.Data.GetData(Target.GetType());
        ListBox container = ((DependencyObject)sender).GetAncestor<ListBox>();
        int RemoveIndex = container.Items.IndexOf(Dropped);
        int TargetIndex = container.Items.IndexOf(Target);
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

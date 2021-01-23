    // somewhere in constructor
    MyPivot.SelectionChanged += MyPivot_SelectionChanged;
    int previousIndex;
    private void MyPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        previousIndex = MyPivot.Items.IndexOf(e.RemovedItems.FirstOrDefault());
        Debug.WriteLine("Previous index: {0}", previousIndex);
    }

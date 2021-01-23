    private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Pivot pivot = sender as Pivot;
        PivotItem selectedPivotItem = pivot.SelectedItem as PivotItem;
        string pivotName = selectedPivotItem.Header.ToString();
        SayWords(pivotName);
    }

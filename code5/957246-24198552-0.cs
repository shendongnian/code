    Protected Overrides Sub OnItemsSourceChanged(oldValue As IEnumerable, newValue As IEnumerable)
        If newValue IsNot Nothing Then
            Dim view As ICollectionView = CollectionViewSource.GetDefaultView(newValue)
            'assign predicate method
            view.Filter= AddressOf Me.FilterPredicate
        End If
        If oldValue IsNot Nothing Then
            Dim view As ICollectionView = CollectionViewSource.GetDefaultView(oldValue)
            'unassign predicate
            view.Filter = Nothing
        End If
        MyBase.OnItemsSourceChanged(oldValue, newValue)
    End Sub

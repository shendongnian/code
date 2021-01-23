     Private Sub ReportView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim gridItemsSourceDescriptor As DependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(DataGrid.ItemsSourceProperty, GetType(DataGrid))
        gridItemsSourceDescriptor.AddValueChanged(Me.DARViewer, _
                                                   New EventHandler(AddressOf OnDataGridItemsSourceChanged))
    End Sub
    Private Sub OnDataGridItemsSourceChanged(sender As Object, e As EventArgs)
        'Code here
    End Sub

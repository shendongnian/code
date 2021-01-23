    myDataGrid.SetBinding(DataGrid.ItemsSourceProperty, new Binding("NewContactList") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Mode = BindingMode.TwoWay });
    myDataGrid.SetValue(DataGrid.DragDropTemplateProperty, dataGrid.FindResource("DragTemplate"));
    myDataGrid.SetValue(DataGrid.ItemTemplateProperty, dataGrid.FindResource("DragTemplate"));
    myDataGrid.SetValue(DragDropHelper.IsDragSourceProperty, True);
    myDataGrid.SetValue(DragDropHelper.IsDropTargetProperty, True);
    myDataGrid.SetValue(DragDropHelper.DragDropTemplateProperty, dataGrid.FindResource("DragTemplate"));

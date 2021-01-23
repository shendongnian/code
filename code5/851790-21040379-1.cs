    myDataGrid.SetBinding(DataGrid.ItemsSourceProperty, new Binding("NewContactList") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Mode = BindingMode.TwoWay });
    myDataGrid.SetResourceReference(DataGrid.DragDropTemplateProperty, "panelTemplate");
    myDataGrid.SetResourceReference(DataGrid.ItemTemplateProperty, "ListTemplate");
    myDataGrid.SetValue(DragDropHelper.IsDragSourceProperty, True);
    myDataGrid.SetValue(DragDropHelper.IsDropTargetProperty, True);
    myDataGrid.SetResourceReference(DragDropHelper.DragDropTemplateProperty, "DragTemplate");

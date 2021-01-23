    private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
    {
        var gridControl = gridLookUpEdit1.Properties.View.GridControl;
        if (e.SelectedControl == gridControl)
        {
            var view = gridControl.GetViewAt(e.ControlMousePosition) as GridView;
            if (view != null)
            {
                object focusedValue = view.GetFocusedRowCellValue(view.Columns[0]);
                if (focusedValue != null)
                    e.Info = new ToolTipControlInfo(view.FocusedRowHandle, focusedValue.ToString());
            }
        }
    }

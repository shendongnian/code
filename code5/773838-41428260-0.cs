    var hitInfo = gridView.CalcHitInfo(e.Location); 
    if(isCtrlPressed && hitInfo.InRow || hitInfo.InRowCell){
        if(isCtrlPressed && gridView.IsRowSelected(hitInfo.RowHandle){
            gridView.UnselectRow(hitInfo.RowHandle);
        }
    }

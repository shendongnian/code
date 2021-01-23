    private void HandleCancel() {
        bool isBoundToDataSourceControl = IsBoundUsingDataSourceID;
    
        DetailsViewModeEventArgs e = new DetailsViewModeEventArgs(DefaultMode, true);
        OnModeChanging(e);
    
        if (e.Cancel) {
            return;
        }
    
        if (isBoundToDataSourceControl) {
            Mode = e.NewMode;
            OnModeChanged(EventArgs.Empty);
        }
    
        RequiresDataBinding = true;
    }
    
    
    
    private void HandleEdit() {
        if (PageIndex < 0) {
            return;
        }
    
        DetailsViewModeEventArgs e = new DetailsViewModeEventArgs(DetailsViewMode.Edit, false);
        OnModeChanging(e);
    
        if (e.Cancel) {
            return;
        }
    
        if (IsBoundUsingDataSourceID) {
            Mode = e.NewMode;
            OnModeChanged(EventArgs.Empty);
        }
    
        RequiresDataBinding = true;
    }
    
    private bool HandleInsertCallback(int affectedRows, Exception ex) {
        DetailsViewInsertedEventArgs dea = new DetailsViewInsertedEventArgs(affectedRows, ex);
        dea.SetValues(_insertValues);
        OnItemInserted(dea);
    
        _insertValues = null;
        if (ex != null && !dea.ExceptionHandled) {
            if (PageIsValidAfterModelException()) {
                return false;
            }
            dea.KeepInInsertMode = true;
        }
    
        if (!dea.KeepInInsertMode) {
            DetailsViewModeEventArgs eMode = new DetailsViewModeEventArgs(DefaultMode, false);
            OnModeChanging(eMode);
            if (!eMode.Cancel) {
                Mode = eMode.NewMode;
                OnModeChanged(EventArgs.Empty);
                RequiresDataBinding = true;
            }
        }
        return true;
    }
    
    private void HandleNew() {
        DetailsViewModeEventArgs e = new DetailsViewModeEventArgs(DetailsViewMode.Insert, false);
        OnModeChanging(e);
    
        if (e.Cancel) {
            return;
        }
    
        if (IsBoundUsingDataSourceID) {
            Mode = e.NewMode;
            OnModeChanged(EventArgs.Empty);
        }
    
        RequiresDataBinding = true;
    }
     
    
    private bool HandleUpdateCallback(int affectedRows, Exception ex) {
        DetailsViewUpdatedEventArgs dea = new DetailsViewUpdatedEventArgs(affectedRows, ex);
        dea.SetOldValues(_updateOldValues);
        dea.SetNewValues(_updateNewValues);
        dea.SetKeys(_updateKeys);
    
        OnItemUpdated(dea);
    
        _updateKeys = null;
        _updateOldValues = null;
        _updateNewValues = null;
    
        if (ex != null && !dea.ExceptionHandled) {
            if (PageIsValidAfterModelException()) {
                return false;
            }
            dea.KeepInEditMode = true;
        }
    
        if (!dea.KeepInEditMode) {
            DetailsViewModeEventArgs eMode = new DetailsViewModeEventArgs(DefaultMode, false);
            OnModeChanging(eMode);
            if (!eMode.Cancel) {
                Mode = eMode.NewMode;
                OnModeChanged(EventArgs.Empty);
                RequiresDataBinding = true;
            }
        }
        return true;
    }

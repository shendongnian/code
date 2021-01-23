        /// <devdoc>
        ///     Refresh the state of the items when the state of the data changes.
        /// </devdoc> 
        private void RefreshItemsInternal() {
            // Block all updates during initialization 
            if (initializing) { 
                return;
            } 
        /// <include file="doc\BindingNavigator.uex" path='docs/doc[@for="BindingNavigator.OnRefreshItems"]/*'> 
        /// <devdoc> 
        ///     Called when the state of the tool strip items needs to be refreshed to reflect the current state of the data.
        ///     Calls <see cref="RefreshItemsCore"> to refresh the state of the standard items, then raises the RefreshItems event. 
        /// </see>
        protected virtual void OnRefreshItems() {
            // Refresh all the standard items
            RefreshItemsCore(); 
 
            // Raise the public event 
            if (onRefreshItems != null) { 
                onRefreshItems(this, EventArgs.Empty);
            } 
        }
        /// <include file="doc\BindingNavigator.uex" path='docs/doc[@for="BindingNavigator.RefreshItemsCore"]/*'>
        /// <devdoc> 
        ///     Refreshes the state of the standard items to reflect the current state of the data. 
        /// </devdoc>
        [EditorBrowsable(EditorBrowsableState.Advanced)] 
        protected virtual void RefreshItemsCore() {
            int count, position;
            bool allowNew, allowRemove;
  
            // Get state info from the binding source (if any)
            if (bindingSource == null) { 
                count = 0; 
                position = 0;
                allowNew = false; 
                allowRemove = false;
            }
            else {
                count = bindingSource.Count; 
                position = bindingSource.Position + 1;
                allowNew = (bindingSource as IBindingList).AllowNew; 
                allowRemove = (bindingSource as IBindingList).AllowRemove; 
            }
  
            // Enable or disable items (except when in design mode)
            if (!DesignMode) {
                if (MoveFirstItem != null)    moveFirstItem.Enabled    = (position > 1);
                if (MovePreviousItem != null) movePreviousItem.Enabled = (position > 1); 
                if (MoveNextItem != null)     moveNextItem.Enabled     = (position < count);
                if (MoveLastItem != null)     moveLastItem.Enabled     = (position < count); 
                if (AddNewItem != null)       addNewItem.Enabled       = (allowNew); 
                if (DeleteItem != null)       deleteItem.Enabled       = (allowRemove && count > 0);
                if (PositionItem != null)     positionItem.Enabled     = (position > 0 && count > 0); 
                if (CountItem != null)        countItem.Enabled        = (count > 0);
            }
 
            // Update current position indicator 
            if (positionItem != null) {
                positionItem.Text = position.ToString(CultureInfo.CurrentCulture); 
            } 
 
            // Update record count indicator 
            if (countItem != null) {
                countItem.Text = DesignMode ? CountItemFormat : String.Format(CultureInfo.CurrentCulture, CountItemFormat, count);
            }
        } 

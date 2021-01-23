    #if WINDOWS_PHONE_APP
        protected override void OnHardwareButtonsBackPressed(object sender, BackPressedEventArgs e) {
            var page = (Page)((Frame)Window.Current.Content).Content;
            if (page.DataContext is IRevertState) {
                var revertable = (IRevertState)page.DataContext;
                if (revertable.CanRevertState()) {
                    revertable.RevertState();
                    e.Handled = true;
                    return;
                }
            }
            base.OnHardwareButtonsBackPressed(sender, e);
        }
    #endif

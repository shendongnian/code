    private void OnTabItemSelecting(object sender, CurrentChangingEventArgs args)
    {
         if(!AllowTabChange)
         {
             var tabControl = sender as TabControl;
             var prevId = tabControl.Items.IndexOf(tabControl.SelectedContent);
             tabControl.SelectedIndex = prevId;
         }
    }

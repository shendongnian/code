      public async void loadview()
      {
        this.ActivateItem(new BlaViewModel(this.events, this.windowManager));
        //displaying it in a tabcontrol, which is defined in XAML. It would probably work with something else too
        var thisView = (ShellView)this.GetView();
        thisView.BlaViewM.SelectedItem
    }

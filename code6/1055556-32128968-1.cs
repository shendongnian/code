    public initializer()
    {
      this.InitializeComponent()
      InputPane.GetForCurrentView().Showing += Keyboard_OnShow;
      InputPane.GetForCurrentView().Hiding += Keyboard_OnHide;
    }
    private void Keyboard_OnShow(InputPane sender, InputPaneVisibilityEventArgs args)
    {
      this.scrllvwrKBScroll.Height = this.ActualHeight - args.OccludeRect.Height - 50;
    }
    private void Keyboard_OnHide(InputPane sender, InputPaneVisibilityEventArgs args)
    {
      this.scrllvwrKBScroll.height = this.ActualHeight;
    }

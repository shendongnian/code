    protected override async void OnActivated(IActivatedEventArgs args)
    {
      if ( args.Kind == ActivationKind.VoiceCommand )
      {
                    Initialize();
                    PrepareApplication();
                    PrepareViewFirst();
                    var service = IoC.Get<IService>();
                    DisplayRootView(typeof(MyView));
      }
    }

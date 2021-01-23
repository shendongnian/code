     protected override void OnActivated(IActivatedEventArgs e)
     {
          base.OnActivated(e);
          // Add all of the Frame code
          var continuationEventArgs = e as IContinuationActivatedEventArgs;
          continuationManager = new ContinuationManager();
          SettingsViewModel settingsPage = SimpleIoc.Default.GetInstance<SettingsViewModel>();
          
          if (continuationEventArgs != null)
          {
              continuationManager.Continue(continuationEventArgs, settingsPage);
          }
      }

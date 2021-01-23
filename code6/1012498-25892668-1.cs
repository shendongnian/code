    private void EnableTouchDownTogglingOfToggleButton()
    {
      EventManager.RegisterClassHandler( typeof( ToggleButton ), ToggleButton.LoadedEvent, new RoutedEventHandler( TurnOnManipulaitonEnabled ) );
      EventManager.RegisterClassHandler( typeof( ToggleButton ), ToggleButton.TouchDownEvent, new RoutedEventHandler( EnableTouchDownTogglingHandler ) );
    }
    private void TurnOnManipulaitonEnabled( object sender, RoutedEventArgs e )
    {
      // need to make sure all toggle buttons behave the same so we always assume IsManipulationEnabled is true
      // otherwise it can open then close right after due to it firing again from mousedown being able to go through
      ToggleButton toggle = sender as ToggleButton;
      if ( toggle != null )
        toggle.IsManipulationEnabled = true;
    }
    private void EnableTouchDownTogglingHandler( object sender, RoutedEventArgs e )
    {
      ToggleButton toggle = sender as ToggleButton;
      if ( toggle != null )
        toggle.IsChecked ^= true;
    }

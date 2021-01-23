    public void TryToFrob()
    {
      if (CanFrob()) DoFrob();
    }
    private bool CanFrob()
    {
      return Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled;
    }
    private void DoFrob()
    {
      // frob!
    }

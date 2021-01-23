    public static class ButtonExtension {
      public static void PerformClick(this Button button){
        var buttonPeer = new System.Windows.Automation.Peers.ButtonAutomationPeer(button);
        var invoker = buttonPeer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
        invoker.Invoke();
      }
    }
    //Usage
    yourButton.PerformClick();

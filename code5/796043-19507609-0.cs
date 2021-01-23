    public class MyEventArgs : EventArgs
    {
      private readonly DeferralManager deferrals = new DeferralManager();
      ... // Your own constructors and properties.
      public IDisposable GetDeferral()
      {
        return deferrals.GetDeferral();
      }
      internal Task WaitForDeferralsAsync()
      {
        return deferrals.SignalAndWaitAsync();
      }
    }

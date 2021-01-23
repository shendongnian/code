    public class DataChangeEventArgs : EventArgs
    {
      private readonly DeferralManager _deferrals;
      public DataChangeEventArgs(DeferralManager deferrals, Journaling.Action a)
      {
        _deferrals = deferrals;
      }
      public IDisposable GetDeferral()
      {
        return deferrals.GetDeferral();
      }
    }

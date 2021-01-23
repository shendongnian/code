    public class Logger 
    {
      ...
      private void Email_OnSent(object sender, EventArgs e)
      {
        LogEvent("Message Sent", DateTime.Now);
      }
      public void LogEvent(string desc, DateTime time)
      {
        ...//some sort of logging happens here
      }
    }

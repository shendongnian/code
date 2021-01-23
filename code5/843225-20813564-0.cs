    public class InputBox
    {
      public class Result //
      (
        DialogResult : ModalResult {get; private set;}
        DateTime : ShutDown {get; private set;}
        ... // more fields as needed
      )
    }
    public Show()
    {
      var result = new Result(); // do not store within form -- prevent G/C of form
      using (myform = new InputBox())
      {
          // pseudocode
          // myform.Initialize();
          // 
          result.ModalResult = myform.ShowDialog(...);  // return
          result.ShowDownTime = myform.controlShutDownTime.Value;
          // myform.Finalize();
      }
    }

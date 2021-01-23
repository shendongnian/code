    public delegate void SuccessHandler();
    public delegate void ErrorHandler(string msg);
    class SomethingModel {
         public event SuccessHandler OnSuccess;
         public event ErrorHandler OnError1;
 
         public void AttemptSomethingAsync() {
             // ...
         }
    }
    // Use it like
    var model = new SomethingModel();
    model.OnSuccess += Yes;
    model.AttemptSomethingAsync();
    private void Yes() {
    }

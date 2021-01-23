    // Called from any method
    Task.Factory.StartNew(UpdateRequest);
    // Background activity
    private void UpdateRequest() {
      UpdateUI("new text everytime" + DateTime.Now.ToString());
    }
    private void UpdateUI(string request)
    {
      if (control.InvokeRequired)
      {
        this.Invoke(new Delegate(UpdateUI), new object[] { request });
      }
     }

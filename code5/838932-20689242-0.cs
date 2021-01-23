    public class MyWindow
    {
      private TaskCompletionSource<String> _tcs = new TaskCompletionSource<String>();
    
      public Task<String> Fetch()
      {
        return _tcs.Task;
      }
    
      public void handleButtonClick(object sender, EventArgs e)
      {
        _tcs.SetResult("some value");
      }
    }
    
    ...
    
    var window = new MyWindow();
    window.Show();
    
    var value = await window.Fetch()

    public class Form1 : Form
    {
      private async void button1_Click(object sender, EventArgs args)
      {
        OnMyEvent("Hello World");
        await Task.Run(
          () =>
          {
            // This stuff runs on a worker thread.
            Thread.Sleep(10000);
          });
        OnMyEvent("Hello World again");
      }
    
      private void OnMyEvent(string foo)
      {
        Message.Show(foo);
      }
    
    }

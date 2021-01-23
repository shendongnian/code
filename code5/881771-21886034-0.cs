    public partial class Form1 : Form
    {
        .....
        public void HandleExceptionFromThread(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    
        public void ButtonClickToRunThread(object sender, System.EventArgs e)
        {
            var syncContext = SynchronizationContext.Current;
            Task task = new Task((state)=>
            {
                SynchronizationContext uiContext = state as SynchronizationContext;
                try
                {
                    ...
                }
                catch(Exception ex)
                {
                    uiContext.Post(HandleExceptionFromThread, ex);
                }
            }, syncContext);
            task.Start();
        }
    }

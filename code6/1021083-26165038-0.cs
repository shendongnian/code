    public class DataViewModel
    {
        public AsynchronousCommand Send;
        public DataViewModel()
        {
            Send = new AsynchronousCommand(() =>
            {
                SendData();
            });
        }
        private void SendData()
        {
        }
    }
    public class SomewhereInForm
    {
        private DataViewModel dataViewModel = new DataViewModel();
        public SomewhereInForm()
        {
            dataViewModel.Send.Executed += SendOnExecuted;
        }
        private void SendOnExecuted(object sender, CommandEventArgs args)
        {
        }
        private void DoSome()
        {
            dataViewModel.Send.DoExecute(new int());
        }
    }

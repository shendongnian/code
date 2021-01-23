    public class Context
    {
        public Context(Dispatcher dispatcher)
        {
            Items = new ObservableCollection<string>();
            Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    dispatcher.BeginInvoke(new Action(() => Items.Add("Test item")));
                }
            });
        }
        public ObservableCollection<string> Items { get; set; }
    }

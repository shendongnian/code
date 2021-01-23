    public class Context
    {
        public Context()
        {
            Items = new ObservableCollection<string>();
            Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Items.Add("Test item")));
                }
            });
        }
        public ObservableCollection<string> Items { get; set; }
    }

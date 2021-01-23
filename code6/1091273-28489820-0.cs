    public class DummyListener : TraceListener
    {
        private readonly MessageBoxView _window = new MessageBoxView();
        private readonly BlockingCollection<string> _messages = new BlockingCollection<string>();
        public DummyListener()
        {
            _window.HideOnClose = true;
            _window.DataContext = _window;
            PresentMessages();
        }
        private async void PresentMessages()
        {
            IEnumerator<string> enumerator = _messages.GetConsumingEnumerable().GetEnumerator();
            while (await Task.Factory.StartNew(() => enumerator.MoveNext(), TaskCreationOptions.LongRunning))
            {
                _window.Title = "Log entry occurred";
                _window.Message = enumerator.Current;
                _window.ShowDialog();
            }
        }
        public override void Write(string message)
        {
        }
        public override void WriteLine(string message)
        {
            _messages.Add(message);
        }
        protected override void Dispose(bool disposing)
        {
            _messages.CompleteAdding();
            base.Dispose(disposing);
        }
    }

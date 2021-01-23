    public class DialogViewModel
    {
        private Task _task;
    
        public DialogViewModel()
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();
    
            _task = Task.Factory.StartNew(() =>
                {
                    var data = GetDataCollection();
                    return data;
                })
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        HasErrored = true;
                        ErrorMessage = "It's borked!";
                    }
                    else
                    {
                        Data = t.Result;
                    }
                }, context);
        }
    
        public IEnumerable<string> Data { get; private set; }
    
        public bool HasErrored { get; private set; }
    
        public string ErrorMessage { get; private set; }
    
        private static IEnumerable<string> GetDataCollection()
        {
            return new List<string>()
            {
                "John",
                "Jack",
                "Steve"
            };
        }
    }

    public partial class WindowB : Window
    {
        private SynchronizationContext _context;
        
        ...
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _context = SynchronizationContext.Current;
        }
        public void PostAction(string data)
        {
            _context.Post(ActualAction,data);
        }
        private void ActualAction(object state)
        {
            Title = state.ToString();
        }
    }

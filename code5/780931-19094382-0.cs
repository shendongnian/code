    class MainForm()
    {
        private TransactionScope _scope;
        public void SaveButton_Click()
        {
            _scope.Complete();
            Close();
        }
        public MainForm()
        {
            _scope = new TransactionScope();
        }
        ~MainForm()
        {
            _scope.Dispose();
        }
    }

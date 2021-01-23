    public class TestViewModel
    {
        private ICommand _testButtonCommand = null;
        public ICommand TestButtonCommand
        {
            get
            {
                if (_testButtonCommand == null)
                {
                    _testButtonCommand = new RelayCommand(param => this.TestButton(), null);
                }
                return _testButtonCommand;
            }
        }
        private void TestButton()
        {
            MessageBox.Show("Test command execute");
        }
    }

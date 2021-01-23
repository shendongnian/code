    public class MainViewModel
    {
        private ColorPickerWindow _colorPicker;
        
        public MainViewModel()
        {
            ShowColorPicker = new DelegateCommand(ShowColorPickerExecute, () => true);
            Ok = new DelegateCommand(OkExecuted, () => true);
            Ok = new DelegateCommand(CancelExecuted, () => true);
            // Create windows instance and set the DataContext to MainViewModel
            _colorPicker = new ColorPickerWindow();
            _colorPicker.DataContext = this;
        }
        public Color Color { get; set; }
        public ICommand ShowColorPicker { get; set; }
        public ICommand Ok { get; set; }
        public ICommand Cancel { get; set; }
        private void CancelExecuted()
        {
            _colorPicker.DialogResult = false;
            _colorPicker.Close();
        }
        private void OkExecuted()
        {
            _colorPicker.DialogResult = true;
            _colorPicker.Close();
        }
        private void ShowColorPickerExecute()
        {
            //Show the ColorPickerWindow
            if (_colorPicker.ShowDialog().GetValueOrDefault(false))
            {
                // Show which color is picked or do whatever you want
                MessageBox.Show(Color.ToString());
            }
            else
            {
                MessageBox.Show(Color.ToString());
            }
        }
    }

    public class EncryptorViewModel : ViewModelBase
    {
        private RelayCommand _cipher;
        private string _inputText;
        private string _outputText;
        public EncryptorViewModel()
        {
            Model = new EncryptorModel();
        }
        private EncryptorModel Model { get; set; }
        #region Public properties
        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                RaisePropertyChanged();
                Cipher.RaiseCanExecuteChanged();
            }
        }
        public string OutputText
        {
            get { return _outputText; }
            set
            {
                _outputText = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands
        public RelayCommand Cipher
        {
            get { return _cipher ?? (_cipher = new RelayCommand(CipherExecute, CipherCanExecute)); }
        }
        private void CipherExecute()
        {
            OutputText = Model.Cipher(InputText);
        }
        private bool CipherCanExecute()
        {
            return !string.IsNullOrWhiteSpace(InputText);
        }
        #endregion
    }

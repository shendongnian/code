    public class EncryptorViewModel : ViewModelBase
    {
        private RelayCommand _cipher;
        private IEncryptor _currentEncryptor;
        private string _inputText;
        private string _outputText;
        public EncryptorViewModel()
        {
            Model = new EncryptorModel();
        }
        private EncryptorModel Model { get; set; }
        public IEnumerable<IEncryptor> AvailableEncryptors
        {
            get
            {
                Type type = typeof (IEncryptor);
                IEnumerable<IEncryptor> encryptors =
                    Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
                        .Select(s => (IEncryptor) Activator.CreateInstance(s));
                return encryptors;
            }
        }
        public IEncryptor CurrentEncryptor
        {
            get { return _currentEncryptor; }
            set
            {
                _currentEncryptor = value;
                RaisePropertyChanged();
                Cipher.RaiseCanExecuteChanged();
            }
        }
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
            OutputText = Model.Cipher(CurrentEncryptor, InputText);
        }
        private bool CipherCanExecute()
        {
            return CurrentEncryptor != null && !string.IsNullOrWhiteSpace(InputText);
        }
        #endregion
    }

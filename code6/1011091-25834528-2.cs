    public partial class MainWindow : Window
    {
        ViewModel viewModel = null;
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = this.DataContext as ViewModel;
        }
        public string defaultText = "user name";
        Stack<string> charStack = new Stack<string>();
        private void PasswordTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.Text = string.Empty;
            var key = e.Key.ToString();
            if (this.viewModel.ObfuscatedPassword == defaultText)
            {
                this.viewModel.ObfuscatedPassword = string.Empty;
            }
            var deleteLastCharacter = (e.Key == Key.Delete || e.Key == Key.Back);
            if (deleteLastCharacter)
            {
                if (charStack.Count > 0)
                {
                    charStack.Pop();
                }
                
                if (charStack.Count == 0)
                {
                    textbox.Text = defaultText;
                    textbox.CaretIndex = defaultText.Length;
                    textbox.SelectAll();
                    e.Handled = true;
                    return;
                }
            }
            else if (IsTextAllowed(key))
            {
                charStack.Push(key);
            }
            else
            {
                e.Handled = true;
                return;
            }
            this.viewModel.ObfuscatedPassword = ObfuscatePassword();
            this.viewModel.ActualPassword = ActualizePassword();
            textbox.CaretIndex = this.viewModel.ObfuscatedPassword.Length;
            e.Handled = true;
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex(@"^.*(?=.{10,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
        private string ActualizePassword()
        {
            var password = string.Empty;
            foreach (var character in charStack.Reverse())
            {
                password += character;
            }
            return password;
        }
        private string ObfuscatePassword()
        {
            var password = string.Empty;
            foreach (var character in charStack.Reverse())
            {
                password += passwordBox.PasswordChar;
            }
            return password;
        }
        private void GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.ObfuscatedPassword == defaultText)
            {
                this.viewModel.ObfuscatedPassword = string.Empty;
            }
        }
        
    }

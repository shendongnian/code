    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication11
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
            {
                var textBox = (TextBox) sender;
                foreach (TextChange textChange in e.Changes)
                {
                    string substring = textBox.Text.Substring(textChange.Offset, textChange.AddedLength);
                    if (substring == "@")
                    {
                        MyPopup.IsOpen = true;
                    }
                    else
                    {
                        MyPopup.IsOpen = false;
                    }
                }
            }
        }
    }

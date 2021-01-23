    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace MessageBoxHelp
    {
        public partial class PDSAMessageBoxView : Window
        {
            private MessageBoxButton buttons;
    
            public PDSAMessageBoxView()
            {
                InitializeComponent();
            }
    
            public static MessageBoxResult Show(string message)
            {
                return Show(message, string.Empty, MessageBoxButton.OK);
            }
    
            public static MessageBoxResult Show(string message,
              string caption)
            {
                return Show(message, caption, MessageBoxButton.OK);
            }
    
            public static MessageBoxResult Show(string message,
              string caption, MessageBoxButton buttons)
            {
                MessageBoxResult result = MessageBoxResult.None;
                PDSAMessageBoxView dialog = new PDSAMessageBoxView();
    
                dialog.Title = caption;
                dialog.tbMessage.Text = message;
                dialog.Buttons = buttons;
                // If just an OK button, allow the user to just 
                // move away from the dialog
                if (buttons == MessageBoxButton.OK)
                    dialog.Show();
                else
                {
                    dialog.ShowDialog();
                    result = dialog.Result;
                }
    
                return result;
            }
    
    
    
    
            public MessageBoxButton Buttons
            {
                get
                {
                    return buttons;
                }
    
                set
                {
                    buttons = value;
    
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnOk.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Collapsed;
    
                    switch (buttons)
                    {
                        case MessageBoxButton.OK:
                            btnOk.Visibility = Visibility.Visible;
                            break;
                        case MessageBoxButton.OKCancel:
                            btnCancel.Visibility = Visibility.Visible;
                            btnOk.Visibility = Visibility.Visible;
                            break;
    
                        case MessageBoxButton.YesNo:
                            btnYes.Visibility = Visibility.Visible;
                            btnNo.Visibility = Visibility.Visible;
                            break;
    
                        case MessageBoxButton.YesNoCancel:
                            btnCancel.Visibility = Visibility.Visible;
                            break;
                    }
                }
            }
    
            public MessageBoxResult Result { get; set; }
    
            private void btnYes_Click(object sender, RoutedEventArgs e)
            {
                Result = MessageBoxResult.Yes;
                this.Close();
            }
    
            private void btnNo_Click(object sender, RoutedEventArgs e)
            {
                Result = MessageBoxResult.No;
                this.Close();
            }
    
            private void btnOk_Click(object sender, RoutedEventArgs e)
            {
                Result = MessageBoxResult.OK;
                this.Close();
            }
    
            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                Result = MessageBoxResult.Cancel;
                this.Close();
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    namespace SLMessageBoxEX
    {
    public partial class SLMessageBox : ChildWindow
    {
        public delegate void MessageBoxClosedDelegate(MessageBoxResult result);
        public event MessageBoxClosedDelegate OnMessageBoxClosed;
        public MessageBoxResult Result { get; set; }
        public SLMessageBox(string title, string message, MessageBoxButtons buttons,MessageBoxIcon icon)
        {
            InitializeComponent();
            this.Closed += new EventHandler(MessageBoxChildWindow_Closed);
            this.Title = title;
            this.txtMsg.Text = message;
            DisplayButtons(buttons);
            DisplayIcon(icon);
        }
        public enum MessageBoxButtons
        {
            Ok, YesNo, YesNoCancel, OkCancel
        }
        public enum MessageBoxIcon
        {
            Question, Information, Error, None, Warning, Logout, ThankYou
        }
        private void DisplayIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBox;component/Images/error.png", UriKind.Relative));
                    break;
                case MessageBoxIcon.Information:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBoxEX;component/Images/Information.png", UriKind.Relative));
                    break;
                case MessageBoxIcon.Question:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBoxEX;component/Images/SIHIImages/question.png", UriKind.Relative));
                    break;
                case MessageBoxIcon.Warning:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBoxEX;component/Images/warning.png", UriKind.Relative));
                    break;
                case MessageBoxIcon.None:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBox;component/Images/Information.png", UriKind.Relative));
                    break;
                case MessageBoxIcon.Logout:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBoxEX;component/Images/logout1.png", UriKind.Relative));
                    break;
                case MessageBoxIcon.ThankYou:
                    imgIcon.Source = new BitmapImage(new Uri("/SLMessageBoxEX;component/Images/ThankYou.png", UriKind.Relative));
                    break;
            }
        }
        private void DisplayButtons(MessageBoxButtons buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtons.Ok:
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Visible;
                    btnYes.Content = "Ok";
                    break;
                case MessageBoxButtons.OkCancel:
                    btnCancel.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Visible;
                    btnYes.Content = "Ok";
                    break;
                case MessageBoxButtons.YesNo:
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnNo.Visibility = Visibility.Visible;
                    btnYes.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btnCancel.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    btnYes.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void MessageBoxChildWindow_Closed(object sender, EventArgs e)
        {
            if (OnMessageBoxClosed != null)
                OnMessageBoxClosed(this.Result);
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (btnYes.Content.ToString().ToLower().Equals("yes") == true)
            {
                //yes button
                this.Result = MessageBoxResult.Yes;
            }
            else
            {
                //ok button
                this.Result = MessageBoxResult.OK;
            }
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.Cancel;
            this.Close();
        }
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.Cancel;
            this.Close();
        }
    }

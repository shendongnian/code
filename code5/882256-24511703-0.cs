    var r = v.ShowDialogOKCancel();
    if (r==MessageBoxResult.OK)
    {
        MessageBox.Show("ok was clicked");
    }
    else
    {
        MessageBox.Show("cancel was clicked");
    }
    static class ModernDialogExtension
    {
        static MessageBoxResult result;
        public static MessageBoxResult ShowDialogOKCancel(this FirstFloor.ModernUI.Windows.Controls.ModernDialog modernDialog)
        {
            result = MessageBoxResult.Cancel;
            modernDialog.OkButton.Click += new RoutedEventHandler(OkButton_Click);
            modernDialog.Buttons = new Button[] { modernDialog.OkButton, modernDialog.CloseButton };
            modernDialog.ShowDialog();
            return result;
        }
        private static void OkButton_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.OK;
        }
    }

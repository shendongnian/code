    private void CommonDialog_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ModernDialog {
                Title = "Common dialog",
                Content = new LoremIpsum()
            };
            dlg.Buttons = new Button[] { dlg.OkButton, dlg.CancelButton};
            dlg.ShowDialog();
            this.dialogResult.Text = dlg.DialogResult.HasValue ? dlg.DialogResult.ToString() : "<null>";
            this.dialogMessageBoxResult.Text = dlg.MessageBoxResult.ToString();
        }

            System.Windows.Forms.DialogResult result = new DialogResult();
            string filePath = string.Empty;
            var invoking = Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                result = dialog.ShowDialog();
                filePath = dialog.SelectedPath;
            }));
            invoking.Wait();

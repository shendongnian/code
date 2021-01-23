    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Blah", "Blah", MessageBoxButton.OK);
            base.OnClosing(e);
        }

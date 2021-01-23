    this.Closing += OnClosing; // For example put this in the constructor of your form
    private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
    {
            string msg = "Do you want to close this?";
            DialogResult result = MessageBox.Show(msg, "Close Confirmation",
                MessageBoxButtons.YesNo/*Cancel*/, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                /* Do something */;
            else if (result == DialogResult.No)
                cancelEventArgs.Cancel = false;
    }

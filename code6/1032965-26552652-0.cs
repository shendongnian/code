        using (var dlg = FindStreet()) {
            // Show main window when dialog is closing
            dlg.FormClosing += new FormClosingEventHandler((s, cea) => {
                if (!cea.Cancel) this.Show();
            });
            // Hide main window after dialog is shown
            this.BeginInvoke(new Action(() => {
                this.Hide();
            }));
            dlg.StartPosition = FormStartPosition.Manual;
            dlg.Location = this.Location;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                // etc...
            }
        }

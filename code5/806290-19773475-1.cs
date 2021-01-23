    private void Dispose_Click(object Sender, EventArgs e)
            {
                TrayIcon.Visible = false;
                TrayIcon.Icon = null;
                TrayIcon.Dispose();
                Application.Exit()
            }

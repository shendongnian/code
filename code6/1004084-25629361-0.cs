    void showMsgOnAllScreens(string msg)
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                AlertForm alert = new AlertForm();
                alert.label1.Text = msg;
                alert.StartPosition = FormStartPosition.Manual;
                alert.Location = new Point(
                    Screen.AllScreens[i].Bounds.Left + (Screen.AllScreens[i].Bounds.Width / 2 - alert.Width / 2),
                    Screen.AllScreens[i].Bounds.Height / 2 - alert.Height / 2);
                alert.Show();
            }
        }

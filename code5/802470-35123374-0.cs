     private void WindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
    if (e.newState == 1)
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    BeginInvoke(new Action(() => {
                        listBox1.SelectedIndex = listBox1.SelectedIndex + 1
                    }));
                }
            }
        }

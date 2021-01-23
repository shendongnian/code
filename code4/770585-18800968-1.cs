    private bool m_cansel = false;
    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        base.OnBackKeyPress(e);
        if (!m_cansel)
        {
            e.Cancel = true;
            m_cansel = true;
            var messageBox = new CustomMessageBox
                {
                    Title = "Title",
                    Message = "Message",
                    RightButtonContent = "aas",
                    IsLeftButtonEnabled = false,
                };
            messageBox.Dismissed += (sender, args) =>
                {
                };
                
            Dispatcher.BeginInvoke(messageBox.Show);
        }
    }

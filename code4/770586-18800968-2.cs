    privatevoid Page_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
    {
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
            messageBox.Dismissed += (s, args) =>
            {
            };
            messageBox.Show();
        }
    }

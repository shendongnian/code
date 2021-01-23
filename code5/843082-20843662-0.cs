    //Message or exception box with an okay button
            public void okNewMessageBox(string title, string message)
            {
                NewMessageBox msgResized = new NewMessageBox(title, message);
                msgResized.StartPosition = FormStartPosition.CenterScreen;
                msgResized.Show();
            }

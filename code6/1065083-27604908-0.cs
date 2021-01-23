    public string ShowMessageBox(string message, string title, string buttons, string icon)
    {
        MessageBoxButton messageBoxButtons;
        switch (buttons.ToLower())
        {
            case "ok": messageBoxButtons = MessageBoxButton.OK; break;
            case "okcancel": messageBoxButtons = MessageBoxButton.OKCancel; break;
            case "yesno": messageBoxButtons = MessageBoxButton.YesNo; break;
            case "yesnocancel": messageBoxButtons = MessageBoxButton.YesNoCancel; break;
            default: messageBoxButtons = MessageBoxButton.OKCancel; break;
        }
        MessageBoxImage messageBoxImage;
        switch (icon.ToLower())
        {
            case "asterisk": messageBoxImage = MessageBoxImage.Asterisk; break;
            case "error": messageBoxImage = MessageBoxImage.Error; break;
            case "exclamation": messageBoxImage = MessageBoxImage.Exclamation; break;
            case "hand": messageBoxImage = MessageBoxImage.Hand; break;
            case "information": messageBoxImage = MessageBoxImage.Information; break;
            case "none": messageBoxImage = MessageBoxImage.None; break;
            case "question": messageBoxImage = MessageBoxImage.Question; break;
            case "stop": messageBoxImage = MessageBoxImage.Stop; break;
            case "warning": messageBoxImage = MessageBoxImage.Warning; break;
            default: messageBoxImage = MessageBoxImage.Stop; break;
        }
        return MessageBox.Show(message, title, messageBoxButtons, messageBoxImage).ToString();
    }

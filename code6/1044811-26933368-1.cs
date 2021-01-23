    public static DialogResult Show(string message, string title, Form owner)
    {
        _msgBox = new MsgBox();
        _msgBox._lblMessage.Text = message;
        _msgBox._lblTitle.Text = title;
        _msgBox.Size = MsgBox.MessageSize(message);
    
        MsgBox.InitButtons(Buttons.OK);
        _msgBox.ShowDialog(owner);
        return _buttonResult;
    }

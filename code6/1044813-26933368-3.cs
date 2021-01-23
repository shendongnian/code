    public static DialogResult Show(string message, string title, Form owner = null)
    {
        _msgBox = new MsgBox();
        _msgBox._lblMessage.Text = message;
        _msgBox._lblTitle.Text = title;
        _msgBox.Size = MsgBox.MessageSize(message);
    
        MsgBox.InitButtons(Buttons.OK);
        if(owner != null)
            _msgBox.ShowDialog(owner);
        else
            _msgBox.ShowDialog();
        return _buttonResult;
    }

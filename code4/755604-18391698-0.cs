    public bool ShowMessageBox(string text)
    {
        var result = MessageBox.Show(text, "", MessageBoxButton.YesNo);
        if (result.Equals(MessageBoxResult.Yes))
        {
            return true;
        }
        return false;
    }

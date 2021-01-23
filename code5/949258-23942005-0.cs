    bool _allowClose = false;
    void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (DetectSecretCombo(e))  //Implement however you see fit.
        {
            _allowClose = true;
            Close();
        }
    }
    void OnClosing(object sender, ClosingEventArgs e)
    {
        _e.Cancel = !_allowClose;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
        {
            FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
        }
    }

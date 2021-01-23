    private void txtpref02_KeyDown(object sender, KeyEventArgs e)
    {
        switch(e.KeyCode)
        {
            case Keys.D0:
            case Keys.D1:
            case Keys.D2:
            case Keys.D3:
            case Keys.Back:
            case Keys.Delete:
                return;
            default:
                e.SuppressKeyPress = true;
                e.Handled = true;
                break;
        }
    }

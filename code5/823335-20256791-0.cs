    private bool _isActive = false;
    public void YourMethod()
    {
        if (!_isActive)
        {
            if (KeyCode == Keys.Enter && InputTextbox.Text.Contains("penny"))
            {
                _isActive = true;
            }
        }
        else
        {
            if (e.KeyCode == Keys.Enter && InputputTextbox.Text.Contains("hello"))
            {
                OutputTextbox.Text = "hi there";
            }
            // other if's
        }
    }

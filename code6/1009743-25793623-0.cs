    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        if (Enabled)
            Text = base.Text;
    }

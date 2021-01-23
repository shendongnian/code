    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            //your button click event handler call here like button1_Click(null, null);
    }

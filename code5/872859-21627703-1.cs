    private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            e.IsInputKey = true;
    }
    private void button1_KeyDown(object sender, KeyEventArgs e)
    {
        e.Handled = true;
    }

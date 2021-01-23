    private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    if (e.Control)
    {
        MessageBox.Show("Ctrl", "Warnung", MessageBoxButtons.OK);
        e.IsInputKey = false;
    }
    else if (e.Alt)
    {
        MessageBox.Show("Alt", "Warnung", MessageBoxButtons.OK);
        e.IsInputKey = false;
    }

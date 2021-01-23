    if (rtf.SelectionFont.Style.HasFlag(FontStyle.Italic))
    {
        rtf.SelectionFont =
            new Font(
                rtf.SelectionFont.FontFamily,
                rtf.SelectionFont.Size,
                rtf.SelectionFont.Style ^ FontStyle.Italic);
    }
    else
    {
        rtf.SelectionFont =
            new Font(
                rtf.SelectionFont.FontFamily,
                rtf.SelectionFont.Size,
                rtf.SelectionFont.Style | FontStyle.Italic);
    }

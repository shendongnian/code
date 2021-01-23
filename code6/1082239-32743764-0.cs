    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (Text.StartsWith(DecoderPrefix))
                SetCurrentValue(TextProperty, Text.Remove(0, DecoderPrefix.Length));
        }
 
        base.OnPreviewKeyDown(e);
    }

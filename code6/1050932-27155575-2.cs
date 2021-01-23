    private void UpdateTextbox(string message, Brush color)
    {
        uiContext.Send(o =>
            {
                TextRange range = new TextRange(rtbOutput.Document.ContentEnd, rtbOutput.Document.ContentEnd);
                range.Text = message;
                range.ApplyPropertyValue(TextElement.ForegroundProperty, color);
            }, null);
    }

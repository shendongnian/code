    private void UpdateTextbox(string message, Color color)
    {
        rtbOutput.Dispatcher.Invoke((Action)(() =>
            {
                TextRange range = new TextRange(rtbOutput.Document.ContentEnd, rtbOutput.Document.ContentEnd);
                range.Text = message;
                range.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((Color)color));
            })
        );
    }

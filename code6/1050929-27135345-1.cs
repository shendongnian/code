    private void UpdateTextbox(string message, Brush Color)
    {
        rtbOutput.Dispatcher.InvokeIfNeeded(() =>
            {
                rtbOutput.Selection.Select(rtbOutput.Document.ContentEnd, rtbOutput.Document.ContentEnd);
                rtbOutput.Selection.Text = message;
                rtbOutput.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Color);
            }
        );
    }

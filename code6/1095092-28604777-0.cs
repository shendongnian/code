    TextRange rangeOfText2 = new TextRange(tbScriptCode.Document.ContentEnd,
        tbScriptCode.Document.ContentEnd);
    rangeOfText2.Text = "RED !";
    rangeOfText2.ApplyPropertyValue(TextElement.ForegroundProperty,Brushes.Red);
    rangeOfText2.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);

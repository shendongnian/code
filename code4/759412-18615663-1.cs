        activeWindow.ActivePane.Selection.WholeStory();
        var text = activeWindow.ActivePane.Selection.Text;
        if(!string.IsNullOrEmpty(text))
        {
            text = text.Replace("a", "b");
            text = text.Remove(text.Length - 1);
        }
        activeWindow.ActivePane.Selection.Text = text;

    var parent = btn.Parent;
    var replacement = new TextBlock { Text = "replacement" };
    if (parent is Panel)
    { 
        var panel = (Panel)parent;
        panel.Children.Remove(btn);
        panel.Children.Add(replacement);
    }
    else if (parent is Decorator)
    { 
        ((Decorator)parent).Child = replacement;
    }
    else if (parent is ContentControl)
    {
        ((ContentControl)parent).Content = replacement;
    }
 

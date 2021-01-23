    Style style = this.FindResource("abc") as Style;
    var r = this.FindResource("styleRed");
    foreach (Setter s in style.Setters)
    {
        if (s.Property == StackPanel.BackgroundProperty)
        {
            s.Value = r;
        }
    }

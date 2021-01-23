    private SolidColorBrush ColorNameToBrush(string colorName)
    {
        Color color = Color.FromArgb(0,0,0,0);
        if (colorName == "Red")
        {
            color = new Color() { R = 255, G = 0, B = 0};
        }
        else if ...
        {
        }
        return new SolidColorBrush(color);
    }

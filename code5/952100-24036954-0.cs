    public string MakeEllipsis(string input, int maxWidth, Font font)
    {
        string output = input;
        Size size = new Size(maxWidth, 0);
        TextRenderer.MeasureText(output, font, size, TextFormatFlags.PathEllipsis | TextFormatFlags.ModifyString);
        return output;
    }

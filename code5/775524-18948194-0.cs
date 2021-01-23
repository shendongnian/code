    // convert the Color type to String notation
    private string ColorToString(Color color)
    {
        return String.Format("{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
    }
    // convert the string notation to color type
    private Color StringToColor(string hexcolor)
    {
        byte r = Convert.ToByte(hexcolor.Substring(0, 2), 16);
        byte g = Convert.ToByte(hexcolor.Substring(2, 2), 16);
        byte b = Convert.ToByte(hexcolor.Substring(4, 2), 16);
        return new Color { R = r, G = g, B = b };
    }
    // This function calculates a gradient from <color1> to <color2> in <steps> steps
    private IEnumerable<Color> GetColorGradient(Color color1, Color color2, int steps)
    {
        int rD = color2.R - color1.R;
        int gD = color2.G - color1.G;
        int bD = color2.B - color1.B;
        for (int i = 1; i < steps; i++)
            yield return new Color
            {
                R = (byte)(color1.R + (rD * i / (steps))),
                G = (byte)(color1.G + (gD * i / (steps))),
                B = (byte)(color1.B + (bD * i / (steps))),
            };
    }
    // This will append two gradients (white->color->black)
    private IEnumerable<Color> GetColorCollection(Color color, int steps)
    {
        int grayValue = (color.R + color.G + color.B) / 3;
        // with the gray value I will determine the lightness of the color, so what step it should start. I don't want 16 white values, when I input a light color.
        int currentStep = (grayValue * steps / 256) - 1;
        yield return Colors.White;
        foreach (Color c in GetColorGradient(Colors.White, color, currentStep))
            yield return c;
        yield return color;
        foreach (Color c in GetColorGradient(color, Colors.Black, steps - currentStep - 1))
            yield return c;
        yield return Colors.Black;
    }
    // this function will convert a IEnumerable<Color> to IEnumerable<string>
    private IEnumerable<string> GetColorCollection(string hexcolor, int steps)
    {
        foreach (Color newColor in GetColorCollection(StringToColor(hexcolor), steps))
            yield return ColorToString(newColor);
    }

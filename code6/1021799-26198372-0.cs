    Dictionary<Color, string> ColorNames = new Dictionary<Color, string>();
    foreach (var color in typeof(Colors).GetRuntimeProperties())
    {
        ColorNames[(Color)color.GetValue(null)] = color.Name;
    }

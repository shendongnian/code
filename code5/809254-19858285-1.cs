    List<Color> allowedColors = new List<Color>();
    if (redCheckBox.IsChecked)
      allowedColors.Add(Color.Red);
    .
    .
    .
    List<Texture> allowedTextures = new List<Texture>();
    if (smoothCheckBox.IsChecked)
      allowedTextures.Add(Texture.Smooth);
    .
    .
    .
      
    filtered = paintList.Where( p => allowedColors.Contains(p.Color) &&
                                  allowedTextures.Contains(p.Texture));

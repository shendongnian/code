    List<Color> lighterColors = new List<Color>();
    List<Color> darkerColors = new List<Color>();
    for(int i = 0; i < 10; i++)
    {
       lighterColors.Add(ControlPaint.Light(color, (float)(i / 10));
       darkerColors.Add(ControlPaint.Dark(color, (float)(i / 10));
    }

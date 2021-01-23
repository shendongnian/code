    if(Button.Background is SolidColorBrush)
    {
        bool isRed = ((SolidColorBrush)Button.Background).Color == Colors.Red;
    }
    else if (Button.Background is GradientBrush)
    {
        ...
    }

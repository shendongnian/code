    if (btn.BackColor.IsKnownColor)
    {
        switch (btn.BackColor.ToKnownColor())
        {
            case KnownColor.Green:
                break;
            case KnownColor.Red:
                break;
            case KnownColor.Gray:
                break;
        }
    }
    else
    {
        // this would act as catch-all "default" for the switch since the BackColor isn't a predefined "Color"
    }

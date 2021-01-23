    private void SetFont(CustomDatePicker view)
    {
        if (view.Font != Font.Default) 
        {
            Control.TextSize = view.Font.ToScaledPixel();
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets,"Roboto-Bold.ttf");
            Control.Typeface = font;
            Control.Typeface = view.Font.ToTypeface();
        }
    }

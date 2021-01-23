    Public class Tools {
        public static Color getColorFromDecimal(decimal corners){
    if (corners < 13)
    {
        return Color.White;
    }
    else if(corners >= 13 && corners < 15)
    {
        return Color.LightGreen;
    }
    else if (corners >= 15 && corners < 17)
    {
        return Color.Yellow;
    }
    else if (corners >= 17 && corners < 19)
    {
        return Color.Orange;
    }
    else
    {
        return Color.Red;
    }
    }
    }

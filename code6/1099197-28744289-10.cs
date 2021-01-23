    public static byte MostDifferent (byte original) {
        if(original < 0x80) {
            return 0xff;
        } else {
            return 0x00;
        }
    }
    public static Color MostDifferent (Color original) {
        byte r = MostDifferent(original.R);
        byte g = MostDifferent(original.G);
        byte b = MostDifferent(original.B);
        return Color.FromArgb(r,g,b);
    }

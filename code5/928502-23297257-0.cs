    public static double Parse(String s) {
        return Parse(s, NumberStyles.Float| NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo);
    }
    public static Decimal Parse(String s) {
        return Number.ParseDecimal(s, NumberStyles.Number, NumberFormatInfo.CurrentInfo);
    }

    public static Color MeanColor(this IEnumerable<Color> list) {
        int count = list.Count();
        // ...
        return Color.FromArgb(r / count, g / count, b / count);
    }

    // closed match for hues only:
    int closestColor1(List<Color> colors, Color target)
    {
        var hue1 = target.GetHue();
        var diffs = colors.Select(n => getHueDistance(n.GetHue(), hue1));
        var diffMin = diffs.Min(n => n);
        return diffs.ToList().FindIndex(n => n == diffMin);
    }
    // closed match in RGB space
    int closestColor2(List<Color> colors, Color target)
    {
        var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n =>n);
        return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
    }
    // weighed distance using hue, saturation and brightness
    int closestColor3(List<Color> colors, Color target)
    {
        float hue1 = target.GetHue();
        var num1 = ColorNum(target);
        var diffs = colors.Select(n => Math.Abs(ColorNum(n) - num1) + 
                                       getHueDistance(n.GetHue(), hue1) );
        var diffMin = diffs.Min(x => x);
        return diffs.ToList().FindIndex(n => n == diffMin);
    }

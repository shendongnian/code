    Color[] clist = new Color[10];
    private void Form1_Load(object sender, EventArgs e)
    {
        clist[0] = Color.Blue;
        clist[1] = Color.BlueViolet;
        clist[2] = Color.Purple;
        clist[3] = Color.Red;
        clist[4] = Color.OrangeRed;
        clist[5] = Color.Orange;
        clist[6] = Color.Yellow;
        clist[7] = Color.YellowGreen;
        clist[8] = Color.Green;
        clist[9] = Color.Turquoise;
        int closIndex1 = closestColor(clist.ToList(), Color.Lavender);
        int closIndex2 = closestColor2(clist.ToList(), Color.Lavender);
        int closIndex3 = closestColor3(clist.ToList(), Color.Lavender);
        Text = closIndex1 + " " + closIndex2 + " " + closIndex3;
    }
    int closestColor(List<Color> colors, Color target)
    {
        int i = -1;
        var pivot = target.GetHue();
        var closestBelow = pivot - colors.Where(n => n.GetHue() <= pivot)
                                         .Min(n => pivot - n.GetHue());
        i = colors.FindIndex(n => n.GetHue() == closestBelow);
        return i;
    }
    int closestColor2(List<Color> colors, Color target)
    {
        int i = -1;
        var pivot = ColorSum ( target);
        var closestBelow = pivot - colors.Where(n => ColorSum (n) <= pivot)
                                         .Min(n => pivot - ColorSum(n));
        i = colors.FindIndex(n => ColorSum(n) == closestBelow);
        return i;
    }
    int closestColor3(List<Color> colors, Color target)
    {
        int i = -1;
        var pivot = ColorNum(target);
        var closestBelow = pivot - colors.Where(n => ColorNum(n) <= pivot)
                                         .Min(n => pivot - ColorNum(n));
        i = colors.FindIndex(n => ColorNum(n) == closestBelow);
        return i;
    }
    int ColorSum(Color c) { return c.R + c.G + c.B; }
    float ColorNum(Color c) { return c.GetHue() + c.GetSaturation() * 50f + c.GetBrightness() * 100f ; }

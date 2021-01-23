    private static readonly CultureInfo EnglishCulture = CultureInfo.GetCultureInfo("en-US");
    private static Tuple<double, double>[] GetData(string[] lines)
    {
        return Array.ConvertAll(lines, line =>
            {
                string[] elems = line.Split(',');
                return new Tuple<double, double>(double.Parse(elems[3], EnglishCulture), double.Parse(elems[1], EnglishCulture));
            });
    }

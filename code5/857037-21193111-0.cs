    public static string ParseComplex(string input)
    {
        Complex final = new Complex();
        Regex regex = new Regex("-? ?[0-9]?[.][0-9]?i?");
        foreach (Match match in regex.Matches(input))
        {
            string noSpaces = match.Value.Replace(" ", string.Empty);
            Complex complex;
            if (noSpaces.EndsWith("i"))
            {
                double value = double.Parse(noSpaces.Replace("i", string.Empty), CultureInfo.InvariantCulture);
                complex = new Complex(0, value);
            }
            else
            {
                double value = double.Parse(noSpaces, CultureInfo.InvariantCulture);
                complex = new Complex(value, 0);
            }
            final = final + complex;
        }
        return final.ToString();
    }

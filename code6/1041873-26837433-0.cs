    public class DistanceNaturalSort : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            try
            {
                var valX = double.Parse(Regex.Match(x, @"\d+(\.\d+)?").Value);
                var valY = double.Parse(Regex.Match(y, @"\d+(\.\d+)?").Value);
                if (valX == valY)
                    return 0;
                else if (valX < valY)
                    return -1;
                else
                    return 1;
            }
            catch (Exception)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }
    }

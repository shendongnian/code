    public class MyComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }
        public string GetStringForHash(string x)
        {
            StringBuilder hashString = new StringBuilder();
            if (x.Length > 2 && x.Substring(0, 2).All(v => char.IsLetter(v)))
            {
                for (var i = 0; i < x.Length; i++)
                {
                    if (char.IsLetter(x[i]))
                    {
                        hashString.Append(x[i]);
                    }
                    else if (char.IsDigit(x[i]))
                    {
                        return hashString.ToString();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return x;
        }
        public int GetHashCode(string x)
        {
            return GetStringForHash(x).GetHashCode();
        }
    }

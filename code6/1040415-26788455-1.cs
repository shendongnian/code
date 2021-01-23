    2^3 * 3 * 5
    2^5 * 3^2 * 5^2
----
    string FormatFactors(int n)
    {
        return String.Join(" * ", 
                  Factors(n).GroupBy(x => x)
                            .Select(g => g.Key + (g.Count() > 1 ? "^" + g.Count() : ""))
                );
    }
    IEnumerable<int> Factors(int n)
    {
        int i=2;
        while(i<=n)
        {
            if (n % i == 0)
            {
                yield return i;
                n /= i;
            }
            else
            {
                i++;
            }
        }
    }

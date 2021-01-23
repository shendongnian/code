    void MyMethod()  
    {
        string fqdn = "host-6.domain.local";
        string[] splitFqdn = fqdn.Split('.');
        List<string> values = new List<string>();
        values.Add("host-1");
        values.Add("host-2.domain.local");
        values.Add("host-3.domain.local");
        values.Add("host-4");
        values.Add("host-5.other.local");
        values.Add("host-5.other.local");
        IEnumerable<string> queryResult = null;
        List<string> correctResult = new List<string>();
        for (int i = splitFqdn.Length; i > 0; i--)
        {
            correctResult = correctResult
                .Union(values.Where(
                     value => value.StartsWith(string.Join(".", splitFqdn.Take(i))))
                .Except(correctResult))
                .ToList();
        }
    }
 

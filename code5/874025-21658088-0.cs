    var values = new List<string> { "Cwts", "Rotc", "Lts" };
    string[] tokens = value
                  .Split(new char[] { '/', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Where(t => values.Contains(t))
                  .Distinct();

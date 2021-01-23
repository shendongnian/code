                List<string> _lookup = new List<string>() { "dE", "SE","yu" };
                IEnumerable<string> _src = new List<string> { "DER","SER","YUR" };
    
                Func<string, List<string>, bool> test = (i,lookup) =>
                {
                    bool ispassed = false;
    
                    foreach (string lkstring in lookup)
                    {
                        ispassed = i.Contains(lkstring, StringComparison.OrdinalIgnoreCase);
    
                        if (ispassed) break;
                    }
    
                    return ispassed;
                    
                };
    
    
                var passedCities = _src.Where(i => test(i, _lookup));

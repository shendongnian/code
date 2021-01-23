    double targetLength = System.Math.Round(totalLinecount / (double)displayColumnCount);
    
    while (result.Count != displayColumnCount)
    {
        result = new List<List<MenuItem>>();
        result.Add(new List<MenuItem>());
        foreach (MenuItem menuItem in menuItems)
        {
            int currentLength = result.Last().Count == 0 ? 0 : result.Last().Sum(s => s.TotalLength);
            if (result.Last().Count == 0 || (currentLength + menuItem.TotalLength) <= targetLength)
            {
                result.Last().Add(menuItem);
            }
            else
                result.Add(new List<MenuItem> { menuItem });
            }
            targetLength++;
        }
    }

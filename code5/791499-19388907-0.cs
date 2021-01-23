    IEnumerable<string> items = new List<string> { "abc", "ab", "abcd", "abcde", "abcdef", "a", "ab", "cde" };
    var filteredList = GimmeFives(items).ToList();
    private IEnumerable<string> GimmeFives(IEnumerable<string> items)
    {
        //"Once an item is processed, I dont need to consider that item again for a combination"
        var indexesProcessed = new List<int>();
        for (int i = 0; i < items.Count(); i++)
        {
            if (indexesProcessed.Contains(i)) { continue; }
            var first = items.ElementAt(i);
            if (first.Length == 5)
            {
                yield return first;
            }
            else
            {
                //Start the second loop after index "i", to avoid including previously processed items:
                for (int j = i+1; j < items.Count(); j++)
                {
                    if (indexesProcessed.Contains(j)) { continue; }
                    var second = items.ElementAt(j);
                    if ((first.Length + second.Length) == 5)
                    {
                        //Remove the middle "+" sign in production code...
                        yield return (first + "+" + second);
                        indexesProcessed.Add(i);
                        indexesProcessed.Add(j);
                        //"Once an item is processed, I dont need to consider that item again for a combination"
                        //"first" has gotten its match, so we don't need to search for another "second":
                        break;
                    }
                }
            }
        }
    }

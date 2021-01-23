    static bool DictEqualsOrderM(Dictionary<string, List<int>> D1, Dictionary<string, List<int>> D2)
    {
        if (D1.Count != D2.Count)
            return false;
        //check keys for equality, than lists.           
        return (D1.Keys.SequenceEqual(D2.Keys) && D1.Keys.All(k => D1[k].SequenceEqual(D2[k])));         
    }
  

      var largestIndex=list.Max(x=>x.Count);
      var listSize=list.Count;
      var result=Enumerable.Range(0, largestIndex)
                           .Select(i => Enumerable.Range(0, listSize)
                           .Where(x => i < list[x].Count)
                           .Select(j => list[j][i]));

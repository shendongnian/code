      var largestIndex=list.OrderByDescending(x=>x.Count).First().Count;
      var listSize=list.Count;
      var result=Enumerable.Range(0, largestIndex)
                           .Select(i => Enumerable.Range(0, listSize)
                           .Where(x => i < list[x].Count)
                           .Select(j => list[j][i]));

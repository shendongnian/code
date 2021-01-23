    var firstLast = seq.Aggregate(
      Tuple.Create(new StringBuilder(), default(string)),
      (sum, cur) => 
         {
           if (sum.Item2 != null)
           {
                sum.Item1.Append(",");
                sum.Item1.Append(sum.Item2);
           }
           return Tuple.Create(sum.Item1, cur);
         });
     firstLast.Item1.Append(SpecialProcessingForLast(sum.Item2));
     return firstLast.Item1.ToString();  

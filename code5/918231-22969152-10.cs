    public static IEnumerable<T> ConcatItems<T>(this IList<T> source, IList<T> dest)
            where T: ISequence
    {
         int index = 0;
         foreach (var x in source)
         {
             if (x.SequenceNumber < dest[index].SequenceNumber)
             {
                 dest.Insert(index, x);
                 continue;
             }
             while(x.SequenceNumber > dest[index].SequenceNumber) index++;
               
             if (index != dest.Count - 1 && x.SequenceNumber == dest[index].SequenceNumber)
             {
                 while (index != dest.Count -1 && 
                     Math.Abs(dest[index].SequenceNumber - dest[index + 1].SequenceNumber) == 1) index++;
                  if (index != dest.Count - 1) dest.Insert(index, x);
                  else dest.Add(x);
                  continue;
             }
             dest.Insert(index, x);
         }
         return dest;
    } 

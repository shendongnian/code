     public class ContiguousValuePeriod<TValue>
     {
         private readonly DateTime start;
         private readonly DateTime end;
         private readonly TValue value;
         public ContiguousValuePeriod(
                 DateTime start,
                 DateTime end,
                 TValue value)
         {
             this.start = start;
             this.end = end;
             this.value = value;
         }
         public DateTime Start { get { return this.start; } }
         public DateTime End { get { return this.start; } }
         public TValue Value { get { return this.value; } }
     }
     public IEnumerable<ContiguousValuePeriod<TValue>>
                         GetContiguousValuePeriods<TValue, TItem>(
             this IEnumerable<TItem> source,
             Func<TItem, DateTime> dateSelector,
             Func<TItem, TValue> valueSelector)
     {
         using (var iterator = source
                 .OrderBy(t => valueSelector(t))
                 .ThenBy(t => dateSelector(t))
                 .GetEnumerator())
         {
             if (!iterator.MoveNext())
             {
                 yield break;
             }
             var periodValue = valueSelector(iterator.Current); 
             var periodStart = dateSelector(iterator.Current);
             var periodLast = periodStart;
             var hasTail = false;
             while (iterator.MoveNext())
             {
                  var thisValue = valueSelector(iterator.Current);
                  var thisDate = dateSelector(iterator.Current);
                  if (!thisValue.Equals(periodValue)  ||
                       thisDate.Subtract(periodLast).TotalDays > 1.0)
                  {
                      // Period change
                      yield return new ContiguousValuePeriod(
                          periodStart,
                          periodLast,
                          periodValue);
                      periodStart = thisDate;
                      periodValue = thisValue;
                      hasTail = false;
                  }
                  else
                  {
                      hasTail = true;
                  }
                  periodLast = thisDate;
              }
          }
          if (hasTail)
          {
              yield return new ContiguousValuePeriod(
                          periodStart,
                          periodLast,
                          periodValue);
          }
      }

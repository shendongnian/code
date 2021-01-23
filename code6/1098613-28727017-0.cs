    public class Point 
    {
        int X {get;set;}
        int Y {get;set;}
    }
    public static IEnumerable<T> Expand(this Range<T> range, Func<T,T> stepFunction)
                                   where T: IComparable<T>
    {
         var current = range.Minimum;
         while (range.Contains(current))
         {
             yield return current;
             current = stepFunction(current);
         }
    }
    // in method
    var pointRange = new Range<Point>(
                       new Point{ X=0,Y=0}, new Point{ X=5, Y=20});
    foreach (Point p in pointRange.Expand(p => new Point{ p.X + 1, p.Y + 4})

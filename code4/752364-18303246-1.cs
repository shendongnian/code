    public class Point {
       //....
       public bool IsBrowsed {get;set;}
    }
    var lst = Points.Select( 
                     x => {
                           var list = Points.Where(z =>!z.IsBrowsed&&dist(x, z) < minDistance).ToList();
                           x.IsBrowsed = true;
                           return list;
                          })
                     .ToList();

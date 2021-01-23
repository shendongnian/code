    //this comparer is used to compare 2 object[]
    public class ArrayComparer : IEqualityComparer<object[]> {
       public bool Equals(object[] x, object[] y) {
         return x.SequenceEqual(y);
       }
       public int GetHashCode(object[] obj){
         return GetHashCode();
       }
    }
    var dup = myTable.AsEnumerable().GroupBy(x => x.ItemArray, new ArrayComparer())
                                    .Where(g=>g.Skip(1).Any())
                                    .Select(g => g.First());
    foreach(var d in dup){
      message += string.Join(", ", d.ItemArray.Cast<string>()) + "\n";
    }
    //E.g
    //Input
    1,2,3
    2,3,4
    3,4,5
    1,2,3
    2,3,4
    //Output
    1,2,3
    2,3,4

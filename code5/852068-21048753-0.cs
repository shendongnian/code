    public class ABC : List<Test1>
    {
       public ABC(IEnumerable<Test1> enumerable)
       {
          if (enumerable != null)
             this.AddRange(enumerable);
       }
    }

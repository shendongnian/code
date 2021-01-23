    public class TestCase
    {
       public static readonly List<object[]> IsSaturdayTestCase = new List<object[]>
       {
          new object[]{new DateTime(2016,1,23),true},
          new object[]{new DateTime(2016,1,24),false}
       };
     
       public static IEnumerable<object[]> IsSaturdayIndex
       {
          get
          {
             List<object[]> tmp = new List<object[]>();
                for (int i = 0; i < IsSaturdayTestCase.Count; i++)
                    tmp.Add(new object[] { i });
             return tmp;
          }
       }
    }

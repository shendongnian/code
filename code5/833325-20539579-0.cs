    public class FakeDbSet<T>
    {
      ....
      public T Find(params object[] keyvalues)
      {
        var keyProperty = typeof(T).GetProperty(
                "Id", 
                BindingFlags.Instance | BindingFlags.Public |  BindingFlags.IgnoreCase);
        var result = this.SingleOrDefault(obj => 
            keyProperty.GetValue(obj).ToString() == keyValues.First().ToString());
        return result;
      }
    }

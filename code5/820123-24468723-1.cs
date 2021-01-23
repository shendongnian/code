    var results = new 
    { 
        customerID = default(int), //notice the casing of property names
        x1 = default(U), //whatever types they are
        x2 = default(V) 
    }.GetEmptyListOfThisType();
    foreach (var customerID in customers) {
      var context = GetContextForCustomer(customerID);
      if (someCondition)
        results.AddRange(myData.Select(x => new { customerID, x.x1, x.x2 }));
    }
    public static List<T> GetEmptyListOfThisType<T>(this T item)
    {
        return new List<T>();
    }

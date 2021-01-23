    var argumentType = IEnumerable<GetData_Result>.GetType().GetGenericArguments()[0];
    var model = new SomeViewModel() 
    {
        var names = argumentType.GetProperties().Select(i => i.Name);
     }

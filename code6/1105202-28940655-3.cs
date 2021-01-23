    List<string> list = new List<string>{"a","b","c"};
    IEnumerable<object> objectlist = list as IEnumerable<object>;    
    IEnumerable<object> newenumerable = objectlist.Take(10);
    Type listTypeOf = newenumerable.FirstOrDefault().GetType();
    Type listType = typeof(List<>).MakeGenericType(listTypeOf);
    dynamic dynamicList = Activator.CreateInstance(listType);
    foreach (var item in newenumerable)
    {
         dynamicList.Add((dynamic) item);
    }
    IEnumerable<string> newenumerableastype = dynamicList as IEnumerable<string>;
            
    Assert.IsNotNull(newenumerableastype);

    IList typedList = null;
    foreach(object item in list) {
        if(typedList == null) {
            typedList = (IList)Activator.CreateInstance(
               typeof(List<>).MakeGenericType(item.GetType()));
        }
        typedList.Add(item);
    }
    return typedList ?? new object[0];

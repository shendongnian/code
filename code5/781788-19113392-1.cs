    IEnumerable<T> items = // code to get initial data, 
                           // set to be an IEnumerable. with default sort applied
    List<string> sortFields = // code to get the sort fields into a list,
                              // in order of selection
    bool isFirst = true;
    foreach (string sortField in sortFields) {
      switch (sortField )
      {
          case "field1":
              if (isFirst) {
                items = items.OrderBy(x => x.Field1);
              } else {
                items = items.ThenBy(x => x.Field1);
              }
              break;
          case "field2":
              if (isFirst) {
                items = items.OrderBy(x => x.Field2);
              } else {
                items = items.ThenBy(x => x.Field2);
              }
              break;
          // perform for all fields
      }
      isFirst = false
    }
    var listOfItems = items.ToList();

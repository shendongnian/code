    // Create 10 objects with 3 properties
    var num_and_name_list =
            from num in Enumerable.Range(1, 10)
            select  new ExtraStringDataPoint ( num, num*2,  ("" + num + "oeu"));
    // Hunting your property starts
    Type myType = num_and_name_list.GetType();
    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
    PropertyInfo order_on_this = null;
    foreach (PropertyInfo prop in props)
    {
        order_on_this = typeof(ExtraStringDataPoint).GetProperty("Y");
    }
    // Here i'll sort them by the name property.
    var sorted_by_name_list =
            from some_object in num_and_name_list
            orderby order_on_this descending
            select some_object;

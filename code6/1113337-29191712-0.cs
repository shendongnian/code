    string[] myMembers = { "ChapterName", "Medium", "LastName", "OrderID" };
    var myDynamicClassList = new List<ExpandoObject>();
    Random random = new Random();
    foreach (var MemberName in myMembers)
    {
        IDictionary<string, object> dynamicClass = (IDictionary<string, object>)(new ExpandoObject());
        dynamicClass.Add(MemberName, random.Next());
        myDynamicClassList.Add((ExpandoObject)dynamicClass);
    }
    foreach (var x in myDynamicClassList)
    {
        foreach (var property in (IDictionary<String, Object>)x)
        {
            Console.WriteLine(property.Key + ": " + property.Value);
        }
    }

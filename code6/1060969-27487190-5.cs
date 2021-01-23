    object[] exampleHayStack = new object[] {
        "This is a test of an indexer", 
        new TestIndexer(),
        null,
        string.Empty,
        new ClassIndexer(),
        new Dictionary<string, string>() { { "key", "value" } },
        new List<string>() { "A", "B", "C", "D", "E", "F", "G" } };
    ClassIndexer myIndexer = new ClassIndexer();
    foreach (var obj in exampleHayStack)
    {
        var methods = myIndexer.GetIndexProperties(obj);
        if (methods == null || methods.Count == 0)
        {
            Console.WriteLine("{0} doesn't have any indexers", obj);
            continue;
        }
        Console.WriteLine("Testing {0}", obj);
        foreach (MethodInfo mi in methods)
        {
            IList<object> indexParams = new List<object>();
            var requiredParams = mi.GetParameters();
            foreach (var par in requiredParams)
            {
                indexParams.Add(myIndexer.ParamForObject(obj, par));
            }
            try
            {
                var result = mi.Invoke(obj, indexParams.ToArray());
                Console.WriteLine("Result of requesting ({0}) = {1}", string.Join(",", indexParams), result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    Console.ReadLine();

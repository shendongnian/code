    if (typeof(T).IsGenericType) {
            var genericTypeParam1 = typeof(T).GetGenericArguments().First();
            Console.WriteLine(genericTypeParam1);
    
            // LINE MARKER 1
            // var obj1AsList = (obj1 as IEnumerable<genericTypeParam1>);
            var genericListType = typeof(IEnumerable<>).MakeGenericType(genericTypeParam1);
    
            Convert.ChangeType(obj1,genericListType);
        }

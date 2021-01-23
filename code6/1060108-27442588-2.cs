    var propTypeDouble = typeof(List<double>);
    var listOfDoubleRuntime = typeof([DelaringType])
                             .GetMethod("GetAsList")
                             .MakeGenericMethod(propTypeDouble.GetGenericArguments().First())
                             .Invoke(null, new[] {"1.1|2.2|3.3"});

    var type = list.GetType().GetGenericArguments()[0];
    var properties = type.GetProperties();
    var result = list.Any(x => properties
                .Any(p =>
                {
                    var value = p.GetValue(x);
                    return value != null && value.ToString().Contains("some string");
                }));

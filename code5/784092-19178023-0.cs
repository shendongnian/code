    var t = value.GetType();
    if (t.IsGenericType) {
        if (t.GetGenericTypeDefinition() == typeof(KeyValuePair<,>)) {
            // OK, it's some type of KVP
            var args = t.GetGenericArguments();
            if (args[0] == typeof(int)) {
                // The Key type is int
            }
        }
    }

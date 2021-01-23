    public static string Transmogrify(string chars) {
        var parts = InnerTransmogrify(chars);
        var result = string.Join("", parts);
        return result;
    }

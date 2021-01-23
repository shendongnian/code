    static class Program
    {
    static byte[] ObjectAsByteArray(object data)
	{
        string text = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings()
        {
            Formatting=Newtonsoft.Json.Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
        });
        return Encoding.UTF8.GetBytes(text);
    }
    static T ByteArrayAsObject<T>(byte[] data)
    {
        var answer = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), typeof(T), new JsonSerializerSettings()
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
        });
        return (T)answer;
    }
    static int Multiply(int a, int b)
    {
        return a * b;
    }
    static T[] ArgumentsOf<T>(Expression<Func<T>> expression)
    {
        MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;
        var Params = outermostExpression.Arguments.Cast<ConstantExpression>().Select(x => (T)x.Value).ToArray();
        return Params;
    }
    [STAThread]
    static void Main()
    {
        var Arguments = ArgumentsOf(() => Multiply(5, 100));
        byte[] ArgAsByte = ObjectAsByteArray(Arguments);
        var DeserializedArguments = ByteArrayAsObject<int[]>(ArgAsByte);
    }
    }

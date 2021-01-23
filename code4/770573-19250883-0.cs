    public string GetMethodName(Action method)
    {
       return method.Method.Name;
    }
    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }
    public static void main(string[] args)
    {
        Console.WriteLine(GetMethodName(SayHello));
    }

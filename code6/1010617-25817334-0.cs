     static void Main()
        {
            Console.WriteLine((X.Y as IConvertible).GetTypeCode());
        }
    public enum X
    {
        Y,
        Z
    }

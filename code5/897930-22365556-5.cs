    enum TransactionData : long
    {
        None = 0,
        Color1 = 1 << 31,
        Color2 = 1 << 63,
    }
    Console.WriteLine(TransactionData.Color1 == TransactionData.Color2); // True

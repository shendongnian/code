    List<decimal> Containers = new List<decimal> {Decimal.Parse("5.11"),
                                                  Decimal.Parse("4.1"),
                                                  Decimal.Parse("7.6"),
                                                  Decimal.Parse("1.9"),
                                                  Decimal.Parse("9.1")};
    decimal actual = 0;
    try
    {
        actual = Math.Round((from c in Containers select c).Sum());
    }
    catch
    {
        actual = 0;
    }
    Console.WriteLine(actual);

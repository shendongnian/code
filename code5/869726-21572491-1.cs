class Program
{
    static void Main()
    {
        decimal dec = 467.45m;
        Console.WriteLine(dec.GetNumberOfDigitsBeforeDecimalPlace());
    }
}
public static class DecimalEx
{
    public static int GetNumberOfDigitsBeforeDecimalPlace(this decimal dec)
    {
        var x = new System.Data.SqlTypes.SqlDecimal(dec);
        return x.Precision - x.Scale;
    }
}

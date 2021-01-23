`cs
/// <summary>
/// Convert decimals to roman numerals
/// </summary>
public static class RomanNumerals
{
    /// <summary>
    /// Dictionary of roman numbers and their equavilant decimals.
    /// IMPORTANT: Keep the order from larger to smaller
    /// </summary>
    public static Dictionary<uint, string> RomanNumbers =
        new Dictionary<uint, string>
        {
            { 1000000, "M̅" },
            { 900000, "C̅M̅" },
                
            { 500000, "D̅" },
            { 400000, "C̅D̅" },
            { 100000, "C̅" },
            { 90000, "X̅C̅" },
            { 50000, "L̅" },
            { 40000, "X̅L̅" },
            { 10000, "X̅" },
            { 9000, "I̅X̅" },
            { 5000, "V̅" },
            { 4000, "I̅V̅" },
            { 1000, "M" },
            { 900, "DM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };
    /// <summary>
    /// Convert decimal number to roman number
    /// </summary>
    /// <param name="number">unsigned number</param>
    /// <returns>Roman number</returns>
    public static string ToRoman(this uint number)
    {
        var romanNum = string.Empty;
            
        while (number > 0)
        {
            // Make sure to order from larger to smaller
            var item = RomanNumbers
                       .OrderByDescending(x => x.Key)
                       .First(x => x.Key <= number);
            romanNum += item.Value;
            number -= item.Key;
        }
        return romanNum;
    }
}
`
Usage :
`cs
uint number = 1000001;
number.ToRoman(); // M̅I
number = 999999;
number.ToRoman(); // C̅M̅X̅C̅I̅X̅DMXCIX
number = 500009;
number.ToRoman(); // D̅IX
`
See: 
 - [How is 1000001 written in Roman](https://www.integers.co/questions-answers/how-is-1000001-written-in-roman-numerals.html)
 - [Decimal to Roman Converter Fiddle](https://dotnetfiddle.net/V61EUS)

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace RomanianNumberToWords
    {
        class Program
        {
            private static string[] _ones =
            {
                "",
                "unu",
                "doua",
                "trei",
                "patru",
                "cinci",
                "sase",
                "sapte",
                "opt",
                "noua"
            };
    
            private static string[] _teens =
            {
                "zece",
                "unsprezece",
                "doisprezece",
                "treisprezece",
                "paisprezece",
                "cincisprezece",
                "saisprezece",
                "saptisprezece",
                "optsprezece",
                "nouasprezece"
            };
    
            private static string[] _tens =
            {
                "",
                "zece",
                "douazeci",
                "treizeci",
                "patruzeci",
                "cincizeci",
                "saizeci",
                "saptezeci",
                "optzeci",
                "nouazeci"
            };
    
            // US Nnumbering:
            private static string[] _thousands =
            {
                "",
                "mie",
                "milion",
                "miliard",
                "trilion",
                "catralion"
            };
    
            
            static string MakeWordFromNumbers(decimal value)
            {
                string digits, temp;
                bool showThousands = false;
                bool allZeros = true;
    
                // Use StringBuilder to build result
                StringBuilder builder = new StringBuilder();
                // Convert integer portion of value to string
                digits = ((long)value).ToString();
                // Traverse characters in reverse order
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    int ndigit = (int)(digits[i] - '0');
                    int column = (digits.Length - (i + 1));
    
                    // Determine if ones, tens, or hundreds column
                    switch (column % 3)
                    {
                        case 0:        // Ones position
                            showThousands = true;
                            if (i == 0)
                            {
                                // First digit in number (last in loop)
                                temp = String.Format("{0} ", _ones[ndigit]);
                            }
                            else if (digits[i - 1] == '1')
                            {
                                // This digit is part of "teen" value
                                temp = String.Format("{0} ", _teens[ndigit]);
                                // Skip tens position
                                i--;
                            }
                            else if (ndigit != 0)
                            {
                                // Any non-zero digit
                                temp = String.Format("{0} ", _ones[ndigit]);
                            }
                            else
                            {
                                // This digit is zero. If digit in tens and hundreds
                                // column are also zero, don't show "thousands"
                                temp = String.Empty;
                                // Test for non-zero digit in this grouping
                                if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
                                    showThousands = true;
                                else
                                    showThousands = false;
                            }
    
                            // Show "thousands" if non-zero in grouping
                            if (showThousands)
                            {
                                if (column > 0)
                                {
                                    bool isFirstThoussand = _thousands[column / 3] == _thousands[1] && ndigit == 1;
    
                                    temp = String.Format("{0}{1}{2}",
                                        isFirstThoussand ? "o " : temp,
                                        isFirstThoussand ? _thousands[1] : "mii",
                                        allZeros ? " " : ", ");
                                }
                                // Indicate non-zero digit encountered
                                allZeros = false;
                            }
                            builder.Insert(0, temp);
                            break;
    
                        case 1:        // Tens column
                            if (ndigit > 0)
                            {
                                temp = String.Format("{0}{1}",
                                    _tens[ndigit],
                                    (digits[i + 1] != '0') ? " si " : " ");
                                builder.Insert(0, temp);
                            }
                            break;
    
                        case 2:        // Hundreds column
                            if (ndigit > 0)
                            {
                                temp = String.Format("{0} {1} ", ndigit == 1 ? "o" : _ones[ndigit], ndigit == 1 ? "suta" : "sute");
                                builder.Insert(0, temp);
                            }
                            break;
                    }
                }
    
                // You always need "lei" right?
                builder.AppendFormat("lei");
    
                // This code simply divides the decimal value by 1; and only adds "si NN bani" if there's a remainder
                if (Decimal.Remainder(value, 1) > 0) {
                    builder.AppendFormat(" si {0:00} bani", (value - (long)value) * 100);
                }
    
                // Capitalize first letter
                return String.Format("{0}{1}",
                    Char.ToUpper(builder[0]),
                    builder.ToString(1, builder.Length - 1));
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine(MakeWordFromNumbers(1127.00M));
                Console.WriteLine(MakeWordFromNumbers(2227.00M));
    
                Console.WriteLine(MakeWordFromNumbers(127.00M));
                Console.WriteLine(MakeWordFromNumbers(227.00M));
    
                Console.ReadKey();
            }
    
        }    
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace GeneratingPrimeNumbers
    {
        class Program
        {
            static void Main(string[] args)
            {
                string string_starting_number = "1"; //input here your choice of starting number
                string string_last_number = "10000"; //input here your choice of last number
                decimal decimal_starting_number = Convert.ToDecimal(string_starting_number);
                decimal decimal_last_number = Convert.ToDecimal(string_last_number);
                string primenumbers = "";
                ulong ulong_b;
                ulong ulong_c;
                if (decimal_starting_number <= ulong.MaxValue)
                {
                    ulong ulong_starting_number = Convert.ToUInt64(decimal_starting_number);
                    ulong ulong_last_number;
                    if (decimal_last_number > ulong.MaxValue)
                    {
                        ulong_last_number = ulong.MaxValue;
                    }
                    else
                    {
                        ulong_last_number = Convert.ToUInt64(decimal_last_number);
                    }
                    ulong ulong_a;
                    for (ulong_a = ulong_starting_number; ulong_a <= ulong_last_number; ulong_a++)
                    {
                        ulong_b = Convert.ToUInt64(Math.Round(Math.Sqrt(ulong_a))) + 1;
                        for (ulong_c = 2; ulong_c <= ulong_b; ulong_c++)
                        {
                            if (ulong_a == 1 || ulong_a == 0 || (ulong_a % ulong_c == 0 && ulong_b != ulong_c))
                            {
                                break;
                            }
                            else if (ulong_b == ulong_c)
                            {
                                primenumbers = primenumbers + " " + ulong_a;
                                break;
                            }
                        }
                    }
                }
                if (decimal_last_number > ulong.MaxValue)
                {
                    string ulong_maximum_value_plus_one = "18446744073709551616";
                    decimal decimal_a;
                    if (decimal_starting_number <= ulong.MaxValue)
                    {
                        decimal_starting_number = Convert.ToDecimal(ulong_maximum_value_plus_one);
                    }
                    for (decimal_a = decimal_starting_number; decimal_a <= decimal_last_number; decimal_a++)
                    {
                        ulong_b = Convert.ToUInt64(Math.Round(Math.Sqrt(ulong.MaxValue) * Math.Sqrt(Convert.ToDouble(decimal_a / ulong.MaxValue)))) + 1;
                        for (ulong_c = 2; ulong_c <= ulong_b; ulong_c++)
                        {
                            if (decimal_a == 1 || decimal_a == 0 || (decimal_a % ulong_c == 0 && ulong_b != ulong_c))
                            {
                                break;
                            }
                            else if (ulong_b == ulong_c)
                            {
                                primenumbers = primenumbers + " " + decimal_a;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(primenumbers);
                Console.ReadKey();
            }
        }
    }

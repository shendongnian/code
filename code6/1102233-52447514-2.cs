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
                string string_last_number = "10"; //input here your choice of last number
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
                    if (ulong_starting_number == 0 || ulong_starting_number == 1 || ulong_starting_number == 2 || ulong_starting_number == 3)
                    {
                        primenumbers = 2 + " " + 3;
                        ulong_starting_number = 5;
                    }
                    if (ulong_starting_number % 2 == 0)
                    {
                        ulong_starting_number++;
                    }
                    ulong ulong_a;
                    for (ulong_a = ulong_starting_number; ulong_a <= ulong_last_number; ulong_a += 2)
                    {
                        ulong_b = Convert.ToUInt64(Math.Ceiling(Math.Sqrt(ulong_a)));
                        for (ulong_c = 3; ulong_c <= ulong_b; ulong_c += 2)
                        {
                            if (ulong_a % ulong_c == 0)
                            {
                                goto next_value_of_ulong_a;
                            }
                        }
                        primenumbers = primenumbers + " " + ulong_a;
                        next_value_of_ulong_a:
                        {
                        }
                    }
                }
                if (decimal_last_number > ulong.MaxValue)
                {
                    string ulong_maximum_value_plus_two = "18446744073709551617";
                    if (decimal_starting_number <= ulong.MaxValue)
                    {
                        decimal_starting_number = Convert.ToDecimal(ulong_maximum_value_plus_two);
                    }
                    if (decimal_starting_number % 2 == 0)
                    {
                        decimal_starting_number++;
                    }
                    decimal decimal_a;
                    for (decimal_a = decimal_starting_number; decimal_a <= decimal_last_number; decimal_a += 2)
                    {
                        ulong_b = Convert.ToUInt64(Math.Ceiling(Math.Sqrt(ulong.MaxValue) * Math.Sqrt(Convert.ToDouble(decimal_a / ulong.MaxValue))));
                        for (ulong_c = 3; ulong_c <= ulong_b; ulong_c += 2)
                        {
                            if (decimal_a % ulong_c == 0)
                            {
                                goto next_value_of_decimal_a;
                            }
                        }
                        primenumbers = primenumbers + " " + decimal_a;
                        next_value_of_decimal_a:
                        {
                        }
                    }
                }
                Console.WriteLine(primenumbers);
                Console.ReadKey();
            }
        }
    }

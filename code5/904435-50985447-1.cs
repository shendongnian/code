            const string formatter = "{0,27:E16}";
            Console.WriteLine(string.Format(formatter, HexStringToDouble("0")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("3FF0000000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("402E000000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("406FE00000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("41EFFFFFFFE00000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("3F70000000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("3DF0000000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("0000000000000001")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("000000000000FFFF")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("0000FFFFFFFFFFFF")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("FFFFFFFFFFFFFFFF")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("FFF0000000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("7FF0000000000000")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("FFEFFFFFFFFFFFFF")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble("7FEFFFFFFFFFFFFF")));
            Console.WriteLine(string.Format(formatter, HexStringToDouble(long.MinValue.ToString())));
            Console.WriteLine(string.Format(formatter, HexStringToDouble(long.MaxValue.ToString())));
            Console.ReadKey();
        }
        
        private static double HexStringToDouble(string hexString)
        {
            double dnumber = 0;
            
            long number;
            bool result = Int64.TryParse(hexString,
                    NumberStyles.HexNumber, CultureInfo.InvariantCulture,
                    out number);
            dnumber=BitConverter.Int64BitsToDouble(number);
            return dnumber;
        }`

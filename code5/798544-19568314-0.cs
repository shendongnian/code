    private static readonly int[][] _conversion =
            {
                new[] {(int) ColorCode.Red, 0x12},
                new[] {(int) ColorCode.Orange, 0x13},
                new[] {(int) ColorCode.LightGreen, 0x17},
                .....
            };
    
        static int ToValue(ColorCode color)
        {
            if (_conversion.Any(c => c[0] == (int) color))
                return _conversion.First(c => c[0] == (int) color)[1];
    
            throw new NotImplementedException(string.Format("Color conversion is not in the dictionary! ({0})", color));
        }
    
        static ColorCode ToEnum(int value)
        {
            if (_conversion.Any(c => c[1] == value))
                return (ColorCode)_conversion.First(c => c[1] == value)[0];
    
            throw new NotImplementedException(string.Format("Value conversion is not in the dictionary! ({0})", value));
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(ToEnum(0x13));
            Console.WriteLine(ToValue(ColorCode.Red));
        }

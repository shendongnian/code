            public static int NumbersInFrontOfDecimal(decimal input)
            {
                NumberFormatInfo currentProvider = NumberFormatInfo.InvariantInfo;
                var newProvider = (NumberFormatInfo)currentProvider.Clone();
                newProvider.NumberDecimalDigits = 0;
    
                var absInput = Math.Abs(input);
                var numbers =  absInput.ToString("N", newProvider);
    
                //Handle Zero and < 1
                if (numbers.Length == 1 && input < 1.0m)
                {
                    return 0;
                }
    
                return numbers.Length;
            }

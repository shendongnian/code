     public static decimal convertFromStringDataToDecimal(decimal x,
                                                                     string positions,
                                                                     string sign)
                {
        
                    // Position
                    double pos;
                    pos = Convert.ToDouble(positions);
        
                    // Dividend
                    decimal dividend = x;
        
                    // Divisor
                    decimal divisor = (decimal)Math.Pow(10, pos);
        
                    // Answer
                    decimal answer;
                    answer = dividend / divisor;
        
                    // Check for negative
                    if (sign == "-")
                    {
                        answer *= -1;
                    }
        
                    // Return Answer
                    return answer;
        
        
                }

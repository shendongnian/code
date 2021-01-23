        enum Conversions
        {
            Inches = 1,
            Feet = 12,
            Yards = 36,
        }
        double DoConversion(string from, string to, double quantity)
        {
            Conversions convertFrom = Conversions.Inches;
            Conversions convertTo = Conversions.Inches;
            if (Enum.TryParse<Conversions>(from, out convertFrom) && Enum.TryParse<Conversions>(to, out convertTo))
            {
                return quantity * ((double)convertFrom / (double)convertTo);
            }
            else 
            {
                return 0;
            }
        }

        private double Rounding(double value, int Precision)
        {
            double result = value;
            if (result.ToString().EndsWith("5"))
            {
                var power = result.ToString().LastIndexOf("5") - 1;
                if (power > Precision)
                {
                    result = result + (1 / Math.Pow(10, power));
                }
            }
            result = Math.Round(result, Precision);
            return result;
        }

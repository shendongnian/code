        private static string calculateTakeHome(string p, double income)
        {
            double numOne = double.Parse(p,System.Globalization.NumberStyles.Currency);
            double outcome = income - numOne;
            return outcome.ToString("C2");
        }

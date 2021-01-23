        public string GenerateLuhnNumber(string baseNumber)
        {
            if (!double.TryParse(baseNumber, out double baseNumberInt))
                throw new InvalidWorkflowException($"Field contains non-numeric character(s) : {baseNumber}");
            var step2 = string.Empty;
            for (var index = baseNumber.Length - 1; index >= 0; index -= 2)
            {
                var doubleTheValue = (int.Parse(baseNumber[index].ToString())) * 2;
                if (doubleTheValue > 9)
                    doubleTheValue = Math.Abs(doubleTheValue).ToString().Sum(c => Convert.ToInt32(c.ToString()));
                step2 = step2.Insert(0, (index != 0 ? baseNumber[index - 1].ToString() : "") + doubleTheValue);
            }
            var step3 = Math.Abs(Convert.ToDouble(step2)).ToString(CultureInfo.InvariantCulture).Sum(c => Convert.ToDouble(c.ToString())).ToString(CultureInfo.InvariantCulture);
            var lastDigitStep3 = Convert.ToInt32(step3[step3.Length - 1].ToString());
            string checkDigit = "0";
            if (lastDigitStep3 != 0)
                checkDigit = (10 - lastDigitStep3).ToString();
            return baseNumber + checkDigit;
        }

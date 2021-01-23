        private decimal GetValueFromTextBox(string input)
        {
            input = System.Text.RegularExpressions.Regex.Replace(input, @"[,$%]", String.Empty);
            //Could use Try parse here for better handling
            decimal output = Convert.ToDecimal(input);
            return output;
        }

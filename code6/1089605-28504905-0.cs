            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            // if input string format is different than a format of current culture
            // input string is considered invalid, unless input string format culture is provided as additional parameter
            string input = "1 234 567,89"; // Russian Culture format
            // string input = "1234567.89"; // Invariant Culture format
            double result = 9.99; // preset before conversion to see if it changes
            bool success = false;
            // never fails
            // if conversion is impossible - returns false and default double (0.00)
            success = double.TryParse(input, out result);
            success = double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
            result = 9.99;
            // if input is null, returns default double (0.00)
            // if input is invalid - fails (Input string was not in a correct format exception)
            result = Convert.ToDouble(input);
            result = Convert.ToDouble(input, CultureInfo.InvariantCulture);
            result = 9.99;
            // if input is null - fails (Value cannot be null)
            // if input is invalid - fails (Input string was not in a correct format exception)
            result = double.Parse(input);
            result = double.Parse(input, CultureInfo.InvariantCulture);

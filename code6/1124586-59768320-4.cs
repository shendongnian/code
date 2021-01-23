            string expression = "-2+4.00*0.20+3.000/06";
            char[] separators = new char[4] { '+', '-', '*', '/' };
            string[] numbers = expression.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < numbers.Length; i++)
            {
                Regex r1 = new Regex(numbers[i]);
                expression = r1.Replace(expression, "X", 1);
            }
            
            for (int i = 0; i < numbers.Length; i++)
            {
                decimal d = Convert.ToDecimal(numbers[i]);
                numbers[i] = d.ToString("0.####");//# 0-28
                if (!numbers[i].Contains(".")) numbers[i] += ".0";
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Regex r2 = new Regex("X");
                expression = r2.Replace(expression, numbers[i], 1);
            }
            if (expression.Contains("/0.0")) return;
            decimal dec = Convert.ToDecimal(new DataTable().Compute(expression, ""));
            result = dec.ToString("0.####");//# 0-28

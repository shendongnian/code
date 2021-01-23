     private string calculate(string text)
        {
            double _out;
            if (double.TryParse(text, out _out))
            {
                return   Math.Sqrt(_out).ToString();
            }
            return text + " is not a value";
        }

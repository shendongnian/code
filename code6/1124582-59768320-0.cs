    public Text text;
    string expression = "";
    public string[] numbers;
    public List<char> operators;
    char[] separators = new char[4] { '+', '-', '*', '/' };
    public void Calculate()
    {
        numbers = text.text.Split(separators);
        for (int i = 0; i < text.text.Length; i++)
        {
            for (int j = 0; j < separators.Length; j++)
            {
                if (text.text[i] == separators[j])
                {
                    operators.Add(text.text[i]);
                }
            }
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i].Contains("."))
            {
                continue;
            }
            else
            {
                numbers[i] = string.Format("{0}.0", numbers[i]);
            }
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            expression += numbers[i];
            if (i < numbers.Length - 1) expression += operators[i];
        }
        decimal solution = Convert.ToDecimal(new DataTable().Compute(expression, null));
        text.text += "=" + solution.ToString("0.####");
    }

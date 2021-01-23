    decimal PromptDecimal(int promptLine)
    {
        while (true)
        {
            Console.SetCursorPosition(promptLine, 12);
            Console.Write(" ");
            Console.SetCursorPosition(promptLine, 12);
            decimal result;
            if (decimal.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
        }
    }

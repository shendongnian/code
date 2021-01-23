    private Choice GiveChoice()
    {
        // This is a label where we can jump to if the input was invalid.
        start:
        // Ask the question.
        Console.Clear();
        Console.WriteLine("Choose (0:Rock, 1:Paper, 2:Scissor):");
        string answer = Console.ReadLine();
        int result = -1;
        // Validate and re-ask if invalid.
        if (!int.TryParse(answer, out result) || (result < 0 && result > 2))
            goto start;
        return (Choice) result;
    }

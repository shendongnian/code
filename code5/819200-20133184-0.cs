    int input = 0;
    while (input < SIZE)
    {
        userInput = Console.ReadLine();
        numberInputed = int.Parse(userInput);
        if (numberInputed == ZERO) {
          break;
        }
        numbers[input] = numberInputed;
        input++;
    }

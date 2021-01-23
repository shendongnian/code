    switch (operation)
    {
        case 'A':
            output = Add(num1, num2);
            break;
        case 'S':
            output = Subtract(num1, num2);
            break;
        case 'M':
            output = Multiply(num1, num2);
            break;
        case 'D':
            output = Divide(num1, num2);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID INPUT!!!!!!!!!!!!!!!");
            Console.ResetColor();
            continue;
    }
    break; // This will exit the loop when a match is found.

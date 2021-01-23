    double sum = 0.0;
    bool continue = true;
    do
    {
        Console.Write("Enter your number: ");
        var input = Console.ReadLine();
        if (input.Length > 0)
        {
            double next = Convert.ToDouble(input);
            if (sum + next <= 100)
            {
                sum += next;
                myList.Add(next);
            }
            else
            {
                Console.WriteLine("Input exceeds quota.");
            }
        }
        else
        {
            continue = false;
        }
    } while (continue);

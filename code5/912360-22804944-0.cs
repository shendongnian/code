    int num = 0;
    int[] userLottery = userRow.Trim()
        .Split(new[] { '.', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Where(s => int.TryParse(s.Trim(), out num) && num > 0 && num < 40)
        .Select(s => num)
        .Distinct()
        .ToArray();
    if(userLottery.Length != 7)
        Console.WriteLine("Enter 7 valid numbers between 1 and 39");
    else
        Console.WriteLine("You have chosen following numbers: " + string.Join(",", userLottery));

        Console.WriteLine("Enter how much numbers");
        int howMuch = int.Parse(Console.ReadLine());
        int[] num = new int[howMuch];
 
        Console.WriteLine("Enter numbers");
        int sum = 0;
        for (int i = 0; i < num.Length; i++ )
        {
            num[i] = int.Parse(Console.ReadLine());
            sum += num[i] * num[i]; // this is what i did but it does not work?
        }
        Console.WriteLine(sum);
        Console.ReadLine();

        String hex = "BB6050C9";  
        int i = 0;
        long sum = 0;
        while (i + 2 <= hex.Length)
        {
            sum += Convert.ToInt64(hex.Substring(i, 2), 16);
            i += 2;
        }
        Console.WriteLine(sum);

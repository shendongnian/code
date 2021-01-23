    public static string stevilo()
    {
        Console.WriteLine("Enter your number! ");
        string vnos = Console.ReadLine();
        int x = Convert.ToInt32(vnos);
        StringBuilder sb = new StringBuilder();
        foreach (var n in Enumerable.Range(0,1000))
        {
            if (n.ToString().ToCharArray().Sum(c => c - '0') == x)
                sb.Append(n.ToString() + ",");   
        }
        if(sb.Length > 0) sb.Length--;
        return sb.ToString();
    }

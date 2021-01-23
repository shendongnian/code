    static void Main(string[] args)
    {
        for (int i =1 ; i<=100;i++)
        {
            Console.WriteLine(i.ToString());
            var name = GetName(i);
            if (name != null)
            {
                Console.WriteLine(name);
            }
        }
    }
    internal static string GetName(int i)
    {
        if (i % 3 == 0)
        {
            if (i % 5 == 0)
            {
                return "HOON Group";
            }
            else
            {            
                return "HOON";
            }
        }
        else if (i % 5 == 0)
        {
            return "Group";
        }
        else
        {
            return null;
        }
    }

    private static void Main()
    {
        if (a())
            if(b())
                if(c())
                    Console.WriteLine("DoSomething");
    }
    static bool a(){
        return true;
    }
    static bool b(){
        return 3 % 2 == 1;
    }
    static bool c(){
        return (3 % 2) / 1 == 1;
    }

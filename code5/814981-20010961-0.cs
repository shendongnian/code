    int n = 0;
    while(n == 0)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
        n = CheckTriang(a, b, c, n);
    }
    
    //replace 'var' by whichever type 'RightTriang' returns.
    var x = RightTriang(a, b, c, x);

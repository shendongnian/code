    static void Main(string[] args)
    {
        for (var i = 0; i < 4; i++)
        {
            int j = i;
            Task.Factory.StartNew(() => SomeMethod(j)); // j as level number
        }
    }

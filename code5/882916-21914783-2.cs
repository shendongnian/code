    static void Main(string[] args)
    {
        var f = new SystemProcessHookForm();
        f.WindowEvent += (sender, data) => Console.WriteLine(data); 
        while (true)
        {
            Application.DoEvents();
        }
    }

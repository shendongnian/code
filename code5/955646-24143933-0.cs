    static void Main(string[] args)
    {
        Console.WriteLine("Opening window...");
        var result = new TestForm().ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
            Console.WriteLine("Form closed by button.");
        else
            Console.WriteLine("Form closed otherwise.");
        Console.ReadLine();
    }

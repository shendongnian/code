    private void Form1_Load(object sender, System.EventArgs e)
    {
        //this gives you the path of the executing assembly
        Console.WriteLine(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
    }

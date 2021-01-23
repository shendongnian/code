    //condition variables
    public static bool CalcStatus = false;
    public static void Calc()
    {
        var calc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "calc.exe"
            },
            EnableRaisingEvents = true,
        };
        calc.Exited += calc_Exited;
        calc.Start();
        CalcStatus = true;
    }
    static void calc_Exited(object sender, EventArgs e)
    {
        MessageBox.Show("CALC has exited");
    }

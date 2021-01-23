    //condition variables
    public static bool CalcStatus = false;
    public static void Calc()
    {
        var calc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "calc.exe"
            }
        };
        calc.Start();
        calc.WaitForExit();
        MessageBox.Show("CALC has exited");
        CalcStatus = true;
    }

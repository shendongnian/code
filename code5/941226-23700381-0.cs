    private void MyTimer_Tick(object sender, EventArgs e)
    {
        Memory oMemory = new Memory(); //Create Memory Class
        if (oMemory.OpenProcess("D4IThermoMeter")) //Open Handle
        {
            double data1 = oMemory.ReadDouble(0x0049E054, new int[] { 0x8 });
            CurrentTemp.Text = data1.ToString();
        }
        this.Refresh();
    }

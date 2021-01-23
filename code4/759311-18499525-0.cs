    public void SetleMotor1()
    {
        if (Form1.InvokeRequired)
        {
            Form1.Invoke(SetleMotor1);
            return;
        }
        
        button1.Enabled = true;
        button2.Enabled = false;
        if (Form1.Motor1.Calibstate == 3)
            label4.Text = "Befejezve";
        else
            label5.Text = "Megállt";
        if (Form1.Motor1.Calibrated)
        {
            label21.Text = "Igen";
            label6.Text = Convert.ToString(Form1.Motor1.MMImp);
        }
        else
        {
            label21.Text = "Nem";
            label6.Text = "-";
        }
    }

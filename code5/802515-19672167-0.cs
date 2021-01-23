    private decimal _Gd;
    private decimal _Qd;
    public void readG_TextChanged(object sender, EventArgs e)
    {
        string _G = readG.Text;
        _Gd = Convert.ToDecimal(_G);
    }
    public void readQ_TextChanged(object sender, EventArgs e)
    {
        string _Q = readQ.Text;
        _Qd = Convert.ToDecimal(_Q);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        decimal _ULS = (1.35m * _Gd + 1.5m * _Qd);
        Console.WriteLine("{0}",_ULS);
    }

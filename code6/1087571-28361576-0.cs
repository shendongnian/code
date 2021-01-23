    void Form1_Load(object sender, EventArgs e)
    {
        string sColor = "#FFACE1AF";// Hex value of any color
        Int32 iColorInt = Convert.ToInt32(sColor.Substring(1), 16);
        Color curveColor = System.Drawing.Color.FromArgb(iColorInt);
        this.BackColor = curveColor;
    }

    private int[] _baudRates = new int[] { 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 76800, 115200, 230400 };
    public Form1()
    {
        InitializeComponent();
        //...
        spinEdit1.Properties.MinValue = 0;
        spinEdit1.Properties.MaxValue = _baudRates.Length - 1;
        spinEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        //...
    }
    private int GetBaudRate(object value)
    {
        return _baudRates[Convert.ToByte(value)];
    }
    private void spinEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
    {
        e.DisplayText = GetBaudRate(e.Value).ToString();
    }

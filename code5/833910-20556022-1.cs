    using System.IO;
    using System.IO.Ports;
    
    public static System.IO.Ports.SerialPort serialPort1;
    private delegate void LineReceivedEvent(string line);
    
    public Form1()
    {
       InitializeComponent();
       System.CompnentModel.IContainer components = new System.ComponentModel.Container();
       serialPort1 = new System.IO.Ports.SerialPort(components);
       serialPort1.PortName = "COM7";
       serialPort1.BaudRate = 9600;
       serialPort1.DtrEnable = true;
       serialPort1.Open();
    }
    private void OnButton_Click(object sender, EventArgs e)
    {
       serialPort1.Write(new byte[] { Convert.ToByte("1") }, 0, 1);
    }
    private void OffButton_Click(object sender, EventArgs e)
    {
       serialPort1.Write(new byte[] { Convert.ToByte("0") }, 0, 1);
    }

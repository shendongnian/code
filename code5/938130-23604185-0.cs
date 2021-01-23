        if(!IsPostBack)
        {
        DropDownList1.Items.Add("COM3");
        DropDownList1.Items.Add("COM2");
        DropDownList1.Items.Add("COM1");
        DropDownList1.Items.Add("COM4");
        DropDownList1.Items.Add("COM5");
        DropDownList1.Items.Add("COM6");
        DropDownList1.Items.Add("COM7");
        DropDownList1.Items.Add("COM8");
        DropDownList1.Items.Add("COM9");
        /*Inicializacija Serialport*/
        serijska_vrata = new SerialPort();
        serijska_vrata.PortName = "COM3";
        serijska_vrata.BaudRate = 9600;
       
            serijska_vrata.Open();
            Button3.Text = "\uf011";
        }

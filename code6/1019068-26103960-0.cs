    private void Form1_Load(object sender, EventArgs e)
    {
        System.Windows.Controls.Expander expander = new System.Windows.Controls.Expander();
        System.Windows.Controls.Grid grid = new System.Windows.Controls.Grid();
        expander.Header = "Sample";
        ElementHost WPFHost = new ElementHost();
        WPFHost.Dock = DockStyle.Fill;
    
        Panel panel1 = new Panel();
        DateTimePicker dtPicker1 = new DateTimePicker();
        Label label1 = new Label();
    
  
        // Initialize the Label and TextBox controls.
        label1.Location = new System.Drawing.Point(16, 16);
        label1.Text = "Select a date:";
        label1.Size = new System.Drawing.Size(104, 16);
        dtPicker1.Location = new System.Drawing.Point(16, 32);
        dtPicker1.Text = "";
        dtPicker1.Size = new System.Drawing.Size(152, 20);
    
        // Add the Panel control to the form. 
        this.Controls.Add(panel1);
        // Add the Label and TextBox controls to the Panel.
        panel1.Controls.Add(label1);
        panel1.Controls.Add(dtPicker1);
    
    
        WindowsFormsHost host = new WindowsFormsHost();
        host.Child = panel1;
    
    
        expander.Content = host;
        WPFHost.Child = expander;
        this.Controls.Add(WPFHost);
    
    }

    public Form1()
    {
       InitializeComponent();
       //Load saved settings
    
       this.Location = Properties.Settings.Default.Form1Location;
       this.Size = Properties.Settings.Default.Form1Size;
       //Allow changes to be implemented
    
       this.StartPosition = FormStartPosition.Manual;
       //capture changes
    
       this.LocationChanged += new EventHandler(Form1_LocationChanged);
       this.SizeChanged += new EventHandler(Form1_SizeChanged);
       //capture the closing form event to save your new settings
    
       this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
    }
    void Form1_LocationChanged(object sender, EventArgs e)
    {
       //Capture the new values
    
       Properties.Settings.Default.Form1Location = this.Location;
    }
    void Form1_SizeChanged(object sender, EventArgs e)
    {
       //Capture the new values
    
       Properties.Settings.Default.Form1Size = this.Size;
    }
    void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
       //you can capture the new values here as well    
       //save the new values
    
       Properties.Settings.Default.Save();
    }

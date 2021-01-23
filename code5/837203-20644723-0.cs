    System.Windows.Forms.Timer timer;
    
    public Form1()
    {
        InitializeComponent();
        this.Controls.Add(pb);
    	
    	timer = new System.Windows.Forms.Timer();
    	timer.Interval = 1000;
    	timer.Tick += (sender, args) => {
    		if (pb.ImageLocation == @"E:\folder\gas_jo.png")
    		{
    			pb.ImageLocation =@"E:\folder\gas_jo_1.png";
    		}
    		else if (pb.ImageLocation == @"E:\Real-time_Imi\gas_jo_1.png")
    		{
    			pb.ImageLocation = @"E:\Real-time_Imi\gas_jo.png";
    		}
    	};
    	timer.Start();
    }
    
    PictureBox pb = new PictureBox
    {
        Location = new Point(0, 0),
        SizeMode = PictureBoxSizeMode.Zoom,
        Size = new Size(300,300),
        ImageLocation = @"E:\folder\gas_jo.png"
    };

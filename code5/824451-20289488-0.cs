        try
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap("C:\\Users\\digit\\Desktop\\C.png");
            picBoxMain.Image = bmp;
            picBoxMain.Visible = true;
            
        }
        catch(Exception ex)
        {
            MessageBox.Show("Error "+ex.Message);
        }

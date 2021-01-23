    private void Form1_Load(object sender, EventArgs e)
    {
        string firstFormFlag = ConfigurationManager.AppSettings["FormToLaunch"].ToString();
        if (firstFormFlag.Equals("small", StringComparison.OrdinalIgnoreCase))
        {
            SmallHotelForm form = new SmallHotelForm();
            form.Show();
        }
        else if (firstFormFlag.Equals("medium", StringComparison.OrdinalIgnoreCase))
        {
            MediumHotelForm form = new MediumHotelForm();
            form.Show();
        }
        else if (firstFormFlag.Equals("Big", StringComparison.OrdinalIgnoreCase))
        {
            BigHotelForm form = new BigHotelForm();
            form.Show();
        }
       
    }

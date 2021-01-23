    Button btn = new Button();
    btn.Tag = <YourImage>; // Here you define which image to show
    btn.MouseLeave += btn_MouseLeave;
    void btn_MouseLeave(object sender, EventArgs e)
    {
         Button b = (Button)sender;
         b.BackGroundImage = (System.Drawing.Image)b.Tag;
    }

    private_void button1_Click(object sender, EventArgs e)
    {
        btnClick++;
        if(btnClick > 7) btnClick = 1; // or 7 if you don't want to loop
        pictureBox1.Image = Image.FromFile(String.Format(@"C:\Users\Korice\Documents\Visual Studio 2012\Projects\.....\form3pic{0}.jpg", btnClick));
    }

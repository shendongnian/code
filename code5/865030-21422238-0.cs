    public async void method()
    {  
         pictureBox1.Visible = true;
         await Task.Delay(2000);
         pictureBox1.Visible = false;
    }

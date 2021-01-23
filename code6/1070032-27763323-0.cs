    async void Button1Click(object sender, EventArgs e)
    {
        pictureBox1.Image = Resource1.Working;
    
        await Task.Run(() => MyFunction());
    
        pictureBox1.Image = Resource1.WorkCompleted;
    }

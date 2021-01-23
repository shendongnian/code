    private async void button1_Click(object sender, EventArgs e)
    {
        progressBar1.MarqueeAnimationSpeed = 50;
        await Task.Delay(5000);
        MessageBox.Show(id);
        pictureBox1.Visible = true;
    }

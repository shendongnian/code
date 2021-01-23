    void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
    {
            if (e.Error != null)
                MessageBox.Show(e.Error.ToString());
    }
    this.pictureBox1.Validated += new EventHandler(pictureBox1_Validated);
    this.pictureBox1.ImageLocation = this.textBox1.Text;

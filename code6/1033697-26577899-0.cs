    public void playDialog(string fileName)
    {
        soundPlayer = new SoundPlayer(fileName);
        soundPlayer.Play();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        playDialog((sender as Button).Tag as string);
    }

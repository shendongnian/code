    async Task PlayTile()
    {
        this.BackColor = Color.Red;
        await Task.Delay(500);
        this.BackColor = Color.White;
        await Task.Delay(500);
    }
    async private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            await PlayTile();
        }
    }

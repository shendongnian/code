    private void NewGame_Click(object sender, EventArgs e)
    {
        Player p = new Player(this.Name); //Create Player class object
        MainWin ng = new MainWin(p); //Pass Player class object
        this.Hide();
        ng.ShowDialog();
        this.Close();
    }

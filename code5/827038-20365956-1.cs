    protected void MusKey_Click(object sender, EventArgs e)
    {
        this.BackColor = Color.Green;
        txt1.Text = Convert.ToString(musicNote); //To test if musicNote refers to   the correct pitch integer.
        form1.AddMusicNote(musicNote, " ");
    }

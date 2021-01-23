    private void btn_AddSongArtistPlaylist_Click(object sender, EventArgs e)
        {
            Artist artist = null;
            if (cmbBox_AddSongPlaylistArtist.SelectedIndex == 0)
            {
                if (cmbBox_Artist.SelectedIndex == 0)
                {
                    artist = new Artist(txtBox_NameArtist.Text, dateTP_BirthdatArtist.Value.Date);
                }
                else 
                {
                    foreach (Artist a in Artists)
                    {
                        if (a.Name == cmbBox_Artist.SelectedText)
                        {
                            artist = a;
                        }
                    }
                }
                Song song = new Song(txtBox_Name.Text, Convert.ToInt32(txtBox_YearBirthday.Text), artist, txtBox_PathToFile.Text); // now you're fine
            }
        }

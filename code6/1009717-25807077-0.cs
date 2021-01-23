    string data;
    JsonValue val = JsonValue.Parse("{\"some json data\": some value,}");
    JsonArray Pl = val.GetObject().GetNamedArray("Playlist");
    for (uint x = 0; x != Pl.Count; x++)//go through each playlist
    {
        var Pl_title = Pl.GetObjectAt(x).GetNamedString("Title"); //get playlist name
        if (Pl_title != txtPlaylistName.Text)//dont do anything if playlist exists
        {
            var Pl_id = Pl.GetObjectAt(x).GetNamedString("UniqueId");
            var Pl_loc = Pl.GetObjectAt(x).GetNamedString("Location");
            var Pl_img = Pl.GetObjectAt(x).GetNamedString("ImagePath");
    
                        //re-create the playlist
            dynamic PlayListObj = new JObject();
            PlayListObj.UniqueId = Pl_id;
            PlayListObj.Title = Pl_title;
            PlayListObj.Location = Pl_loc;
            PlayListObj.ImagePath = Pl_img;
            GroupObj.Playlist.Add(PlayListObj);
    
            PlayListObj.Songs = new JArray() as dynamic;
    
            JsonArray Sng = Pl.GetObjectAt(x).GetNamedArray("Songs");
            for (uint y = 0; y != Sng.Count; y++)
            {
                var Sng_id = Sng.GetObjectAt(y).GetNamedString("UniqueId");
                var Sng_title = Sng.GetObjectAt(y).GetNamedString("Title");
                var Sng_lyr = Sng.GetObjectAt(y).GetNamedString("Lyrics");
                var Sng_loc = Sng.GetObjectAt(y).GetNamedString("Location");
                //re-create the songs in the playlist
                dynamic SongObj = new JObject();
                SongObj.UniqueId = Sng_id;
                SongObj.Title = Sng_title;
                SongObj.Lyrics = Sng_lyr;
                SongObj.Location = Sng_loc;
                PlayListObj.Songs.Add(SongObj);
            }
                    }
                    else
                        txtBerror.Text = "The name: " + txtPlaylistName.Text + " already exists.";
                }
                if (txtPlaylistName.Text != string.Empty)
                {
                    //re-create the playlist
                    dynamic newPlayListObj = new JObject();
                    newPlayListObj.UniqueId = "PL " + txtPlaylistName.Text;
                    newPlayListObj.Title = txtPlaylistName.Text;
                    newPlayListObj.Location = "";
                    newPlayListObj.ImagePath = "";
                    GroupObj.Playlist.Add(newPlayListObj);
    
                    newPlayListObj.Songs = new JArray() as dynamic;
    
                    for (int a = 0; a != 3; a++)//number of songs
                    {
                        dynamic SongObj = new JObject();
                        SongObj.UniqueId = "Sng " + "file name";
                        SongObj.Title = "file name";
                        SongObj.Lyrics = "";
                        SongObj.Location = "";
                        newPlayListObj.Songs.Add(SongObj);
                    }
                                }
                else
                    txtBerror.Text = "Enter a playlist name";
    
    data = GroupObj.ToString();
    await Windows.Storage.FileIO.WriteTextAsync(newFile, data);//write to the file

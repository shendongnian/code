    XDocument doc = new XDocument();
                  XElement songsElement = new XElement("Songs");
                  foreach(var musicfile in musicfiles)
                  {
                      XElement songElement = new XElement("Song");
                      string songTitle;
                        try { songTitle = (TagLib.File.Create(musicfile).Tag.Title); }
                        catch { songTitle = "Missing"; }
                      uint songTNint;
                        try { songTNint = (TagLib.File.Create(musicfile).Tag.Track); }
                        catch { songTNint = 00; }
                        string songTN = songTNint.ToString();
                      string songPath = musicfile;
                      string songArtist;
                        try {songArtist = (TagLib.File.Create(musicfile).Tag.Performers[0]);}
                        catch {songArtist = "Missing";}
                      List<string> songGenres = new List<string>();
                      foreach (string Genre in (TagLib.File.Create(musicfile).Tag.Genres))
                      { songGenres.Add(Genre);}
                      string songGenre;
                      if (songGenres.Count > 1) { songGenre = (songGenres[0] + "/" + songGenres[1]); }
                      else { try { songGenre = songGenres[0]; } catch { songGenre = "Missing"; } }
                      songArtist = Regex.Replace(songArtist, @"[^\u0020-\u007E]", string.Empty);
                      XElement titleElement = new XElement("Title",songTitle);
                      XElement tnElement = new XElement("TN", songTN);
                      XElement pathElement = new XElement("Path", musicfile);
                      XElement artistElement = new XElement("Artist",songArtist);
                      XElement genreElement = new XElement("Genre", songGenre);
                      songElement.Add(titleElement);
                      songElement.Add(tnElement);
                      songElement.Add(pathElement);
                      songElement.Add(artistElement);
                      songElement.Add(genreElement);
                      songsElement.Add(songElement);
                  }

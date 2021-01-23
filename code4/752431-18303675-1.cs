    ResultsListBox.ItemsSource = from songs in band.Descendants("songs")
                                 from song in songs.Descendants("song")
                                 select new Song {
                                                  Name = song.Attribute("name").Value,
                                                  Sum = song.Attribute("sum").Value,
                                                  Number = song.Attribute("number").Value
                                                 };

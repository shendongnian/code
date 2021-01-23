    int n_lines = Convert.ToInt32(sr.ReadLine());
    var songs = new Song[n_lines];
    for (int i = 0; i < n_lines; i++)
    {
        string line = sr.ReadLine();
        string[] columns = line.Split(new char[] {' '}, 4);
        string[] subcolumns = columns[3].Split(':');
        int minutes = Convert.ToInt32(column[1]);
        int seconds = Convert.ToInt32(column[2]);
        songs[i] = new Song {
            Channel = Convert.ToInt32(column[0]),
            Length = new TimeSpan(0, minutes, seconds), 
            Author = subcolumns[0],
            Name = subcolumns[1]
        };
    }

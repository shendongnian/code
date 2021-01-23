    static internal bool isDuplicate(string path)
            {
                bool contains = Song.AllSongs.Any(s => s.path == path);
                return contains;
            }

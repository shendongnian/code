    internal class PlayList : IEnumerable<SongID>
    {
        private List<SongID> songsInAlbum = new List<SongID>();
        int currentIndex = 0; //maintain an index per instance; 1-based
        int Count //make it public if it makes sense
        {
            get { return songsInAlbum.Count; }
        }
        public Song this[SongID id]
        {
            get
            {
                if (songsInAlbum.Contains(id))
                {
                    return AllSongs[id];
                }
                throw new KeyNotFoundException();
            }
        }
    
        public IEnumerable<Song> Next(int noOfSongs)
        {
            try 
            {
                return this.Skip(currentIndex).Take(noOfSongs).Select(x => AllSong[x]);
            }
            finally
            {
                if (currentIndex < Count)
                    currentIndex += Math.Min(Count - currentIndex, noOfSongs);
            }
        }
        public IEnumerable<Song> Next() //or 'Rest', sounds good.
        {
            return Next(int.MaxValue); //less readable
            //or
            return Next(Count); //a more meaningful number
            //or
            return Next(Count - currentIndex); //for correctness
        }
    
        public void AddSong(SongID id)
        {
            songsInAlbum.Add(id);
        }
    
        public IEnumerator<SongID> GetEnumerator() //general enumerator, enumerates them all
        {
            return songsInAlbum.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public Artist GetSelectedArtist(string aName)
            {
                var result = (sourceArtists.Single(u => u.ArtistName == aName));
                var index = sourceArtists.IndexOf(result);
                GlobalVars._artistID = index;
                return result;
            } 

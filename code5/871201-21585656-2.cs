       private XDocument m_Songs;
         public Audio()
        { 
             m_Songs = XDocument.Load("My XML Source");
        }
        public void playSong(string songName)
        {
            XElement match = m_Songs.Descendants()
                .Where(x => x.Name.LocalName == "song")
                .FirstOrDefault(x => x.Attribute("name").Value == "songName");
            if (match == null)
                return;
            
            songlist.TryGetValue(match.Attribute("file").Value, out music);
            MediaPlayer.Play(music);
        }

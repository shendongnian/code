                foreach(Videos v in l)
                {
                   if(MyPlaylist.Contains(v))
                   {
                       MyPlaylist.Remove(v);
                   }
                }
                l.Clear();
            

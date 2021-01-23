            int totalitems = MyPlaylist.Count;
            List<Videos> l = new List<Videos>();
            for (int index = totalitems - 1; index >= 0; index--)
            {
                Videos video = MyPlaylist.ElementAt(index);
                if (video.Id == id)
                {
                    l.Add(video);
                }
            }

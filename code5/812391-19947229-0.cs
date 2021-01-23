            for (int index = MyPlaylist.Count - 1; index >= 0; index--)
            {
                Videos video = MyPlaylist.ElementAt(index);
                if (video.Id == id)
                {
                    MyPlaylist.RemoveAt(index);
                }
            }

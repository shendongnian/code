    public static PlaylistItem Create(PlaylistItemDto playlistItemDto, IPlaylistManager playlistManager)
    {
        PlaylistItem playlistItem = new PlaylistItem
            {
                Cid = playlistItemDto.Cid,
                Id = playlistItemDto.Id,
                Playlist = playlistManager.Get(playlistItemDto.PlaylistId),
                Sequence = playlistItemDto.Sequence,
                Title = playlistItemDto.Title,
                Video = Video.Create(playlistItemDto.Video)
            };
        return playlistItem;
    }

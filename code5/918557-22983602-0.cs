    public class ApplicationResponse
    {
        public IList<string> Errors { get; set; }
        public dynamic Data { get; set; }
        public bool HasErrors()
        {
            return Errors != null && Errors.Any();
        }
    }
    public ApplicationResponse GetPlaylistId(long songInPlaylistId)
    {
        var songInPlaylist = service.GetById(songInPlaylistId);
        if (songInPlaylist == null)
        {
            return new ApplicationResponse { Errors = new[] { "Song was not found." } };
        }
        if (songInPlaylist.Playlist == null)
        {
            return new ApplicationResponse { Errors = new[] { "Playlist was not found." } };
        }
        return new ApplicationResponse { Data = songInPlaylist.Playlist.Id };
    }
    public HttpResponseMessage SomeRequest([FromUri] songInPlaylistId)
    {
        var response = appService.GetPlaylistId(long songInPlaylistId);
        if (response.HasErrors())
        {
            // reply with error status
        }
        // reply with ok status
    }

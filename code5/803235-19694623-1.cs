    public AudioTracks GetAudioTracks(AudioTrackSearchOptions searchOptions)
    {
        AudioTracks audioTracks;
        using (MidasDataContext dataContext = DataContext)
        {
            audioTracks = new AudioTracks(
                from audioTrack in dataContext.DbAudioTracks
                join masterTrack in dataContext.DbMasterTracks on audioTrack.MasterTrackId equals masterTrack.Id
                join masterTrackArtist in dataContext.DbDataLists on masterTrack.ArtistId equals masterTrackArtist.Id
                orderby string.Concat(masterTrack.Title, " (", audioTrack.Mix, ") - ", masterTrackArtist.Text)
                where (searchOptions.IsInactiveAudioTrackIncluded || audioTrack.IsActive)
                && (searchOptions.IsDeletedAudioTrackIncluded || !audioTrack.IsDeleted)
                select new AudioTrack(audioTrack.Id, masterTrack.Id, audioTrack.Isrc, masterTrack.Title, masterTrackArtist.Text, audioTrack.Mix, audioTrack.IsContentExplicit, audioTrack.IsActive, audioTrack.IsDeleted));
        }
        audioTracks.Sort(a => a.TitleWithMix);
        return audioTracks ?? new AudioTracks();
    }

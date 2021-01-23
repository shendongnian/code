        try
        {//
            var pathUri = await YouTube.GetVideoUriAsync("GC2qk2X3fKA", YouTubeQuality.Quality480P);
            player.Source = pathUri.Uri;
        }
        catch (Exception ex)
        {
            if (ex is FormatException)
            {
                // handle exception. 
                // For example: Log error or notify user problem with file
            }
        }

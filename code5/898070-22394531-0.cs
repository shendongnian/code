    YouTube.RemoveTag(obj, Upload.UploadId.ToString());
    internal static void RemoveTag(Video video, string tag)
    {			
    	video.Snippet.Tags.Remove(tag);
    	var updateRequest = YouTubeService.Videos.Update(video, Constants.PartSnippet);
    	updateRequest.ExecuteAsync();
    }

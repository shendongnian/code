    YouTube.DeleteAsyncVideoByGuidTag(Upload.UploadId);
    
    internal async static Task DeleteAsyncVideoByGuidTag(Guid tag)
    {
    	var listRequest = YouTubeService.Search.List(Constants.PartSnippet);
    	listRequest.ForMine = true;
    	listRequest.Type = Constants.TypeVideo;
    	listRequest.Q = tag.ToString();
    	var response = await listRequest.ExecuteAsync();
    	foreach (var deleteRequest in response.Items.Select(
    		result => YouTubeService.Videos.Delete(result.Id.VideoId)))				
    		await deleteRequest.ExecuteAsync();
    }

            string developerkey = "developerKey";
            YouTubeRequestSettings settings = new YouTubeRequestSettings("Somethinghere", developerkey, "googleUserName", "googlePassWord");
            YouTubeRequest request = new YouTubeRequest(settings);
          
            newVideo.Title = "Video Title Here || ArgeKumandan";
            newVideo.Tags.Add(new MediaCategory("Autos", YouTubeNameTable.CategorySchema));
            newVideo.Keywords = "cars, funny";
            newVideo.Description = "My description";
            newVideo.YouTubeEntry.Private = false;
            newVideo.Tags.Add(new MediaCategory("mydevtag, anotherdevtag", YouTubeNameTable.DeveloperTagSchema));
            // alternatively, you could just specify a descriptive string
            // newVideo.YouTubeEntry.setYouTubeExtension("location", "Mountain View, CA");
            newVideo.YouTubeEntry.MediaSource = new MediaFileSource(@"D:\video ArgeKumandan.flv", "video/flv");
            
            createdVideo  = request.Upload(newVideo);

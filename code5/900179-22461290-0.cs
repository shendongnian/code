    private void GetYoutubePlaylist(string feedXML)
            {
                try
                {
                    StringReader stringReader = new StringReader(feedXML);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
    
                    
                    YoutubeVideo video = null;
    
                    foreach (SyndicationItem item in feed.Items)
                    {
                        video = new YoutubeVideo();
    
                        video.YoutubeLink = item.Links[0].Uri;
                        string a = video.YoutubeLink.ToString().Remove(0, 31);
                        video.Id = a.Substring(0, 11);
                        video.Title = item.Title.Text;
                        video.PubDate = item.PublishDate.DateTime;
    
                        video.Thumbnail = YouTube.GetThumbnailUri(video.Id, YouTubeThumbnailSize.Small);
    
                        videosList.Add(video);
                    }
                    if (video != null)
                    {
                        MainListBox.ItemsSource = null; //Just add this
                        MainListBox.ItemsSource = videosList;                    
                    }
                }
                catch { }
            }

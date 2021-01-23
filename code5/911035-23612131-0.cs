          try
            {
                YouTubeRequestSettings settings = new YouTubeRequestSettings("YoutubeLibrary", DeveloperKey);
                settings.Timeout = 120000;
                int start = 1;
                int maxResult = 50;
                int totalVideosCroned = 0;
                var videosLimit=5; //how many max playlistID want ?? add here
                if (videosLimit < maxResult)
                {
                    maxResult = videosLimit;
                }
                YouTubeRequest request = new YouTubeRequest(settings);
                do
                {
                    totalVideosCroned += maxResult;
                    string uri = "http://gdata.youtube.com/feeds/api/users/";
                    
                    if (!string.IsNullOrEmpty(youtubeID))
                    {
                        uri += youtubeID  +"/playlists";
                        uri += "?key=" + DeveloperKey + "&start-index=" + start + "&max-results=" + maxResult;
                        //handle Playlist not found issue // use code for handling URL data 
                        string reponse = GetHttpResponseForPlayList(uri);
                       
                       
                           
                            start += maxResult;
                            
                            var videoEntryUrl = new Uri(uri);
                            Feed<Video> videoFeed = request.Get<Video>(videoEntryUrl);
                            foreach (Video entry in videoFeed.Entries)
                            {
                                string playlistId = Regex.Replace(entry.Id, ".*:playlist:", "");
                                //Do cron youtube with playlist ID now
                       CronPlaylistYoutubeVideo(playlistId);
                                totalVideosCroned = videosLimit;  // explicitly condition full feel to stop loop .
                            }
                            
                            /*if (videoFeed.Entries.Count() < 50)  // if need to get more playlist records, : i.e if userAccount has 100 playlist then to get all, this should be uncomment
                            {
                                totalVideosCroned = videosLimit;
                            }*
                             
                            /* This code will get 25 playlist records without use of gdata URI
                             * Feed<Playlist> userPlaylists = request.GetPlaylistsFeed(channelfilter.AccountName);
                            foreach (Playlist playlistInfo in userPlaylists.Entries)
                            {
                                Uri playlistEntryUri = new Uri(playlistInfo.Self);
                                CronPlaylistYoutubeVideo(playlistEntryUri.Segments[6], channelfilter, channel, videosLimit);
                                totalVideosCroned = videosLimit; // explicitly stop loop.
                            }*/
                        
                    }
                    else
                    {
                        totalVideosCroned = videosLimit;
                    }
                } while (totalVideosCroned < videosLimit);
            }
            catch (Exception ex)
            {
               //handle it if need..
                return;
            }

    public class VideoLibrary
    {
        private WebClient thumbnailDownloader = new WebClient();
        private Queue<VideoItem> downloadQueue = new Queue<VideoItem>();
        private bool isBusy = false;
        public ObservableCollection<VideoItem> Videos = new ObservableCollection<VideoItem>();
        public VideoLibrary()
        {
            thumbnailDownloader.OpenReadCompleted += OnThumbnailDownloaded;
        }
        // It will not start downloading process but only add a new video item (without thumbnail) to download queue.
        public void Download(string url)
        {
            downloadQueue.Enqueue(new VideoItem(url)); // Just add to queue.
            CheckQueue();
        }
        // Check whether there are new thumbnails to download. If so, start downloading just one.
        private void CheckQueue()
        {
            if (isBusy) // Stop! Downloading in progress...
                return;
            if (downloadQueue.Count > 0)
            {
                isBusy = true;
                VideoItem item = downloadQueue.Peek();
                thumbnailDownloader.OpenReadAsync(new Uri(item.Url));
            }
        }
        // One thumbnail has been downloaded. We can add it to the list of videos and check the queue again.
        private void OnThumbnailDownloaded(object sender, OpenReadCompletedEventArgs e)
        {
            isBusy = false;
            if (e.Cancelled)
            {
                CheckQueue(); // Just try again.
            }
            else if (e.Error != null)
            {
                downloadQueue.Dequeue(); // Skip this video (thumbnail), check the next one.
                CheckQueue();
            }
            else if (downloadQueue.Count > 0)
            {
                VideoItem item = downloadQueue.Dequeue(); // Remove the video from queue.
                WriteableBitmap bitmap = new WriteableBitmap(null); 
                bitmap.SetSource(e.Result);
                item.Thumbnail = bitmap; // Thumbnail is ready to use.
                Videos.Add(item); // Add to list.
                CheckQueue();
            }
        }
    }

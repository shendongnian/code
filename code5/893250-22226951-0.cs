    public void Images()
    {
        var images = new ObservableCollection<string>();
        var wcf = new ServiceReferenceVideo.VideoServiceClient();
        foreach (var item in wcf.GetAllVideos())
        {
            string link_thumb = wcf.GetThumbImage((wcf.GetVideoId(item.urlVideo)));
            images.Add(link_thumb);
        }
        _imageList.ItemsSource = images;
    }

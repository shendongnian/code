    private void LoadPicture(string url)
    {
        threadworker = new Thread(() => pictureBox1.Image = getImgFromUrl(url));
        threadworker.Start();
    } 
    public Bitmap getImgFromUrl(string url)
    {
        Bitmap bmp = null;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            try
            {
                bmp = new Bitmap(response.GetResponseStream());
                .
                .
                .

    private int _currentImageIndex;
    private string[] _imagePaths =
    {
        "Images/Enemy.png",
        "Images/Enemy2.png",
        "Images/Enemy3.png",
    };
    ...
    void NextImage()
    {
        // Dispose the current image
        Image img = pictureBox1.Image;
        pictureBox1.Image = null;
        if (img != null)
            img.Dispose();
        // Show the next image
        _currentImageIndex = (_currentImageIndex + 1) % _imagePaths.Length;
        string path = _imagePaths[_currentImageIndex];
        pictureBox1.Image = Image.FromFile(path);
    }

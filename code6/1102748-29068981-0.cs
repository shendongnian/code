    this.Timer.Stop();
    Bitmap image = null;
    var temp = this.PictureBox.Image;
    lock (FRAMEKEY)
    {
        if (this.ImageQueue.Any())
        {
            image = this.ImageQueue.Dequeue();
            if (temp != null) { temp.Dispose(); }
        }
    }
    this.PictureBox.Image = image;
    if (temp != null) { temp.Dispose(); }
    this.Timer.Start();

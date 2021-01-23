    Stream stream = isoStore1.OpenFile("Explode.mp4", System.IO.FileMode.Open, System.IO.FileAccess.Read );
    
                    this.mediaElement.Stop();
                    this.mediaElement.SetSource(stream);
    mediaElement.Play();

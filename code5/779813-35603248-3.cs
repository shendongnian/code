    var s = SynchronizationContext.Current;
    // assuming pb is your PictureBox
    await Start("http://whateverurlthatstreamsmjpegs.com", 
        img => {
            s.Post(new SendOrPostCallback(i => {
                if(pb.Image != null)
                    pb.Image.Dispose();
                pb.Image = (Image)new ImageConverter().ConvertFrom((byte[])i);
            }), img);
        }, 1024, CancellationToken.None);

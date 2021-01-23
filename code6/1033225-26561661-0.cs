    SemaphoreSlim processImageDopLimiter = new SemaphoreSlim(8);
    
    //...
    
    var page = ...; //transform block input
    var images = GetImages(page);
    ImageWithPage[] processedImages =
     images
     .AsParallel()
     .Select(i => {
        processImageDopLimiter.WaitOne();
        var result = ProcessImage(i);
        processImageDopLimiter.ReleaseOne();
        return result;
     })
     .ToList();
    return images;

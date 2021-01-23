    public static async Task ChangeSourceAfter(this Image imageToAnimate, double sec, ImageSource src)
    {
     await Task.Delay(Timespan.FromSeconds(sec));
    
     //Now change image source, also trigger animation if PropertyChangedTrigger used
     imageToAnimate.Source = src;
    
    }

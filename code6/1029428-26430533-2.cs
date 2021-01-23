    List<int> newImageList = new List<int>();
    
    for(int i = 0; i < CurrentImage.Header.Height)
    {
       newImageList.AddRange(PPMImageLibrary.GrayscaleImage(CurrentImage.ImageListData)); // I am assuming your GrayscaleImage method might return multiple records.
        
    }
    
    
